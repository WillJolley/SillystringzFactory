using System.Collections.Generic;
using System.ComponentModel.Data;

namespace Factory.Models
{
  public class Engineer
  {
    public string Name { get; set; }
    public string Specialty { get; set; }
    public int EngineerId { get; set; }
    public List<EngineerMachine>JoinEntities { get; }
  }
}