//#if DNX451
//using System.IO;
//using System.IO.MemoryMappedFiles;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//namespace WebApi.Cache
//{
//    public static class FileMapCache
//    {
//        private static ManualResetEventSlim _mapCreated = new ManualResetEventSlim(initialState: false);
//        private static ManualResetEventSlim _dataWrittenEvent = new ManualResetEventSlim(initialState: false);
//        public static int Capacity { get; set; } = 10000;
//        public static Task<string> Get(string key)
//        {
//            return Task.Run(() => {
//                string results = string.Empty;
//                _mapCreated.Wait();
//                using (MemoryMappedFile mappedFile = MemoryMappedFile.OpenExisting(key, MemoryMappedFileRights.Read))
//                {
//                    using (MemoryMappedViewAccessor accessor = mappedFile.CreateViewAccessor(0, Capacity, MemoryMappedFileAccess.Read))
//                    {
//                        _dataWrittenEvent.Wait();
//                        ushort Size = accessor.ReadUInt16(0);
//                        byte[] Buffer = new byte[Size];
//                        accessor.ReadArray(0 + 2, Buffer, 0, Buffer.Length);
//                        results = ASCIIEncoding.ASCII.GetString(Buffer);
//                    }
//                }
//                return results;
//            });
//        }
//        public static Task Set(string key, string value)
//        {
//            return Task.Run(async () => {
//                await SleepAsync(2);
//                byte[] Buffer = ASCIIEncoding.ASCII.GetBytes(value);
//                using (MemoryMappedFile mappedFile = MemoryMappedFile.CreateFromFile(key, FileMode.Create, key, Capacity))
//                {
//                    _mapCreated.Set();
//                    using (MemoryMappedViewAccessor accessor = mappedFile.CreateViewAccessor(0, Capacity, MemoryMappedFileAccess.Write))
//                    {
//                        accessor.Write(0, (ushort)Buffer.Length);
//                        accessor.WriteArray(0 + 2, Buffer, 0, Buffer.Length);
//                        _dataWrittenEvent.Set();
//                    }
//                }
//            });
//        }
//        private static Task SleepAsync(int MS)
//        {
//            return Task.Run(() => {
//                Thread.Sleep(MS);
//            });
//        }
//    }
//}
//#endif