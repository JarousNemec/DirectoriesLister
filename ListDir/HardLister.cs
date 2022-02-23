using System;
using System.Collections.Generic;
using System.IO;

namespace ListDir
{
    public class HardLister
    {
        private DirsCursor _cursor;
        private int mainDirsCount;
        public void PrintDirectory(string path)
        {
            mainDirsCount = Directory.GetDirectories(path).Length;
            //Check if we have there some directories
            if (Directory.GetDirectories(path).Length == 0)
            {
                return;
            }

            //initialize directory cursor
            _cursor = new DirsCursor();
            PrintDirectoryAndAllFilesInside(_cursor.GetDirs(), path);
            //main listing cycle
            bool run = true;
            while (run)
            {
                //Diving
                string targetDir = GetPathToDirByCursor(_cursor.GetDirs());
                if (Directory.GetDirectories(targetDir).Length != 0)
                {
                    PrintDirectoryAndAllFilesInside(_cursor.GetDirs(), targetDir);
                    _cursor.AddDir(0);
                    continue;
                }

                //Climbing
                PrintDirectoryAndAllFilesInside(_cursor.GetDirs(), targetDir);
                if (IsDirEndThere())
                {
                    do
                    {
                        _cursor.RemoveLastDir();
                        if (IsThisEndOfStructure())
                        {
                            run = false;
                            break;
                        }

                    } while (IsDirEndThere());

                    _cursor.IncreaseLastDirPointerByOne();
                }
                else
                {
                    _cursor.IncreaseLastDirPointerByOne();
                }
            }
        }

        private bool IsThisEndOfStructure()
        {
            if ((_cursor.GetDirsCount() == 1) && (_cursor.GetDirs()[0] + 1 == mainDirsCount))
            {
                return true;
            }
            return false;
        }

        private bool IsDirEndThere()
        {
            return Directory.GetDirectories(GetPathToDirByCursor(_cursor.GetCursorWithoutLastPointer())).Length ==
                    _cursor.GetLastItem() + 1;
        }

        private void PrintDirectoryAndAllFilesInside(List<int> dirs, string targetDir)
        {
            Console.WriteLine(" " + new string(' ', dirs.Count - 1) + "+ " + Path.GetFileName(targetDir));
            foreach (var file in Directory.GetFiles(targetDir))
            {
                Console.WriteLine(" " + new string(' ', dirs.Count - 1) + "- " + Path.GetFileName(file));
            }
        }

        private string GetPathToDirByCursor(List<int> pathStruct)
        {
            string currentDir = Directory.GetCurrentDirectory();
            string targetDir = currentDir;
            foreach (var dirIndex in pathStruct)
            {
                string[] tempDirs = Directory.GetDirectories(targetDir);
                targetDir += "\\" + Path.GetFileName(tempDirs[dirIndex]);
            }
            return targetDir;
        }
    }
}