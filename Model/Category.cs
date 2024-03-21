using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PracticaEf.Model
{
    public class Category
    {
        
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        [JsonIgnore]//lo agregue para que no salga error la peticion en postman
        public virtual ICollection<TaskModel> Tasks { get;}
    }
}
