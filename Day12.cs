using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent2021
{
    class Day12 : DayBase
    {

        public class Cave
        {
            public Cave(string Name)
            {
                CaveName = Name;
                isBigCave = char.IsUpper(CaveName[0]);
            }

            public string CaveName = "";
            public bool isBigCave = false;
            public List<Cave> Connections = new List<Cave>();

            public void ConnectCaves(Cave targetCave)
            {
                Connections.Add(targetCave);
                targetCave.Connections.Add(this);
            }

        }

        public class Path
        {
            public List<Cave> path = new List<Cave>();
            public bool visistedTwice = false;

            public Path() { }

            public Path(Path origin, Cave node)
            {
                foreach (Cave c in origin.path)
                {
                    path.Add(c);
                }
                path.Add(node);
                visistedTwice = origin.visistedTwice;
            }

            public Cave Last()
            {
                return path[path.Count - 1];
            }
        }

        public List<Cave> Caves = new List<Cave>();

        public List<Path> ExploreStack = new List<Path>();

        private bool showDebug = false;

        public override bool RunPart1()
        {
            if (LoadInput())
            {
                int awnser = GetAllPaths(false);
                Console.WriteLine("The awnser to day 12 part 1 is: " + awnser);
                return true;
            }
            return false;
        }

        public override bool RunPart2()
        {
            if (LoadInput())
            {
                int awnser = GetAllPaths(true);
                Console.WriteLine("The awnser to day 12 part 2 is: " + awnser);
                return true;
            }
            return false;
        }
        public override bool LoadInput()
        {
            if (base.LoadInput())
            {
                string[] Connection;
                while (!MyFileStream.EndOfStream)
                {
                    Connection = MyFileStream.ReadLine().Split('-');
                    Cave cave1 = GetCave(Connection[0]);
                    Cave cave2 = GetCave(Connection[1]);
                    cave1.ConnectCaves(cave2);
                }
                return true;
            }
            return false;
        }

        public Cave GetCave(string caveName)
        {
            Cave result = Caves.Find(x => x.CaveName == caveName);
            if (result == null)
            {
                result = new Cave(caveName);
                Caves.Add(result);
            }
            return result;
        }

        public int GetAllPaths(bool IncludeTwice)
        {
            int pathCount = 0;
            Path seed = new Path();
            seed.path.Add(GetCave("start"));
            ExploreStack.Add(seed);
            while (ExploreStack.Count != 0)
            {
                Path currentPath = ExploreStack[0];
                ExploreStack.RemoveAt(0);

                if (currentPath.Last().CaveName == "end")
                {
                    pathCount++;
                    if (showDebug)
                    {
                        for(int i = 0; i < currentPath.path.Count-1; i++)
                        {
                            Console.Write(currentPath.path[i].CaveName + ",");
                        }
                        Console.WriteLine("end");
                    }
                    continue;
                }

                foreach (Cave connection in currentPath.Last().Connections)
                {
                    if (connection.CaveName != "start")
                    {
                        if (connection.isBigCave)
                            ExploreStack.Add(new Path(currentPath, connection));
                        else
                        {
                            if (!currentPath.path.Contains(connection))
                            {
                                ExploreStack.Add(new Path(currentPath, connection));
                            }
                            else if (IncludeTwice && !currentPath.visistedTwice)
                            {
                                ExploreStack.Add(new Path(currentPath, connection) { visistedTwice = true });
                            }
                        }
                    }
                }
            }
            return pathCount;
        }

    }
}
