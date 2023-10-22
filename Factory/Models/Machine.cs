using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
  public class Machine
  {
    [Required(ErrorMessage = "Cannot leave machine's name empty!")]
    public string Name { get; set; }
    public string Description { get; set; }
    public int MachineId { get; set; }
    public List<EngineerMachine> JoinEntities { get; }
  }
}