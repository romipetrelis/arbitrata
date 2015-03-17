using System.Collections.Generic;
using KnockoutWebForms.Models;

namespace KnockoutWebForms
{
    internal class SuperheroService
    {
        public IEnumerable<SuperheroModel> GetSuperheroes()
        {
            return new[]
            {
                new SuperheroModel{AlterEgo = "Bruce Wayne", Name="Batman", IsCaped =true},
                new SuperheroModel{AlterEgo = "Peter Parker", Name="Spiderman", IsCaped = false},
                new SuperheroModel{AlterEgo = "Clark Kent", Name="Superman", IsCaped = true},
                new SuperheroModel{AlterEgo = "Tony Stark", Name="Iron Man", IsCaped = false}
            };
        }
    }
}