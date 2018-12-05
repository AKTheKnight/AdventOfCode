using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Net.Sockets;

namespace uk.co.aktheknight.AdventOfCode.Challenges._2017
{
    public class DayTwelve2017 : Challenge
    {
        private static List<string> Input { get; set; }
        
        public DayTwelve2017() : base(12)
        {
            if (Input == null)
                Input = Utils.GetInput(2017, 12);
        }

        public override string SolutionOne()
        {
            var programs = new List<Program>();
            for (var i = 0; i < Input.Count; i++)
            {
                programs.Add(new Program(i));
            }
            
            for (var i = 0; i < Input.Count; i++)
            {
                var line = Input[i].Split(new[] {"<->"}, StringSplitOptions.RemoveEmptyEntries).ToList();
                var program = int.Parse(line[0]);

                var connectedProgramIds = line[1].Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                
                foreach (var programId in connectedProgramIds)
                {
                    if (programs[program].IsConnected(programId))
                        continue;
                    programs[program].Connections.Add(programs[programId]);
                    programs[programId].Connections.Add(programs[program]);
                }
            }

            return programs[0].GetAllInGroup().Count.ToString();
        }

        public override string SolutionTwo()
        {
            var programs = new List<Program>();
            for (var i = 0; i < Input.Count; i++)
            {
                programs.Add(new Program(i));
            }
            
            for (var i = 0; i < Input.Count; i++)
            {
                var line = Input[i].Split(new[] {"<->"}, StringSplitOptions.RemoveEmptyEntries).ToList();
                var program = int.Parse(line[0]);

                var connectedProgramIds = line[1].Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                
                foreach (var programId in connectedProgramIds)
                {
                    if (programs[program].IsConnected(programId))
                        continue;
                    programs[program].Connections.Add(programs[programId]);
                    programs[programId].Connections.Add(programs[program]);
                }
            }

            var groups = new List<List<Program>>();
            
            foreach (var program in programs)
            {
                bool isInGroup = false;
                foreach (var group in groups)
                {
                    if (group.Any(p => p.ID == program.ID))
                        isInGroup = true;
                }
                
                if (isInGroup)
                    continue;

                groups.Add(program.GetAllInGroup());
            }
            
            return groups.Count.ToString();
        }
    }

    class Program
    {
        public int ID { get; private set; }
        public List<Program> Connections { get; set; }

        public Program(int id)
        {
            ID = id;
            Connections = new List<Program>();
        }

        public bool IsConnected(int connectionId)
        {
            return Connections.Any(p => p.ID == connectionId);
        }

        public List<Program> GetAllInGroup(List<Program> group = null)
        {
            if (group == null)
                group = new List<Program>();

            foreach (var connection in Connections)
            {
                if (!group.Contains(connection))
                {
                    group.Add(connection);
                    group.AddRange(connection.GetAllInGroup(group));
                    group = group.Distinct().ToList();
                }
            }

            return group;
        }
    }
}