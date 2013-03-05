using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Collections.Concurrent;

namespace librSimulate.galaxygen
{
	public class ByteStorage
	{
		#region [ Static Members ]
		public static byte[] bql_start_of_file = new Byte[4] { 0,0,0,0 };
		public static byte[] bql_end_of_file = new Byte[4] { 1,1,1,1 };


		public enum ByteColumnType 
		{
			SpaceID = 0,
			ParentID = 1,
			TypeID = 2,
			ID = 3,
		}

		public enum ByteStorageState
		{
			OFFLINE = 0,
			ONLINE = 1,
			READ_ONLY = 2
		}
	
		public static int RowFieldSize = 128;
		public static DateTime StarTime = DateTime.Now;
		public static ByteStorageState StorageState =  ByteStorageState.OFFLINE;
		public static Boolean GlobalLock = false;
		public static Boolean QueingEnabled = true;
		public static int QueSize = 10;
		public static ConcurrentQueue<ByteCommand> CommandQueue =  new ConcurrentQueue<ByteCommand>();

		public static void ConfigureServer ()
		{
			ByteStorage.CommandQueue = new ConcurrentQueue<ByteCommand>();
		}

		public static void QueCommand (ByteCommand command)
		{
			if (ByteStorage.QueingEnabled) 
			{
				if (ByteStorage.CommandQueue.Count >= ByteStorage.QueSize) 
				{

				}
				else
				{
					ByteStorage.CommandQueue.Enqueue(command);
				}
			}
		}

		public static void StartServer()
		{

		}
		#endregion

		public String FilePath { get; set; }

		#region [ Constructors ]
		public ByteStorage (String FilePath)
		{
			this.FilePath = FilePath;
		}
		#endregion

		#region [ Repository Commands ]
		public void create(byte[,,] row)
		{
		
		}

		public void upsert(byte[,,] row)
		{

		}

		public void get(byte[,,] query)
		{

		}

		public void delete(byte[,,] row)
		{

		}
		#endregion

		private byte[] seek (ByteCommand command)
		{
			byte[] result = new byte[command.Length];
			if (ByteStorage.StorageState != ByteStorageState.OFFLINE) {
				if (!ByteStorage.GlobalLock) {

					try
					{
						var sequence = File.ReadAllBytes(this.FilePath);

						int i = 0;
						int c = sequence.Length;

						while(i <= (c-1))
						{
							if( (c -i) >= 4)
							{
								byte[] seq_set = new byte[]{ sequence[i],sequence[i +1],sequence[i + 2],sequence[i + 3] };

								if(sequence[ByteColumnType.SpaceID] == command.pattern[ByteColumnType.SpaceID])
								{
									if(sequence[ByteColumnType.ParentID] == command.pattern[ByteColumnType.ParentID])
									{
										if(sequence[ByteColumnType.TypeID] == command.pattern[ByteColumnType.TypeID])
										{
											if(sequence[ByteColumnType.ID] == command.pattern[ByteColumnType.ID])
											{
												// the Key is found get the value;
											}
										}
									}
								}

							}

							i = i + 5;
						}

					}
					catch(Exception x)
					{
						throw x;
					}
					finally
					{
						ByteStorage.GlobalLock = false;
					}
				}
			}  
		}

		private void persist(ByteCommand command)
		{
			if (!ByteStorage.GlobalLock) {
				byte[] data_bytes = File.ReadAllBytes(this.FilePath);
				using (var stream = new FileStream(this.FilePath, FileMode.Append))
				{
					stream.Write(data_bytes,0,data_bytes.Length);
				}
			}
		}

	}


	public enum ByteCommandType 
	{
	}
	public struct ByteCommand 
	{
		public byte Length {
			get;
			set;
		}

		public byte[] pattern;
	}
}

