using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
  public class Engineer
  {
    [Required(ErrorMessage = "Cannot leave engineer's name empty!")]
    public string Name { get; set; }
    public string Specialty { get; set; }
    public int EngineerId { get; set; }
    public List<EngineerMachine> JoinEntities { get; }
  }
}