using System.Collections.Generic;

namespace ListDir
{
    public class DirsCursor
    {
        private List<int> dirs;

        public DirsCursor()
        {
            dirs = new List<int>();
            AddDir(0);
        }

        public void AddDir(int n)
        {
            dirs.Add(n);
        }

        public List<int> GetDirs()
        {
            return dirs;
        }

        public int GetDirsCount()
        {
            return dirs.Count;
        }

        public void RemoveLastDir()
        {
            if (dirs.Count > 1) {
                dirs.RemoveAt(dirs.Count - 1);
            }
        }

        public void IncreaseLastDirPointerByOne()
        {
            dirs[dirs.Count - 1] += 1;
        }

        public int GetLastItem()
        {
            return dirs[GetDirsCount() - 1];
        }
        
        public List<int> GetCursorWithoutLastPointer()
        {
            List<int> newItems = new List<int>();
            for (int i = 0; i < dirs.Count - 1; i++)
            {
                newItems.Add(dirs[i]);
            }

            return newItems;
        }
    }
}