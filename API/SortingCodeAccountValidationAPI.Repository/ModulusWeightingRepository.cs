using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using SortingCodeAccountValidationAPI.Domain.Enums;
using SortingCodeAccountValidationAPI.Domain.Model.Modulus.Responses;
using SortingCodeAccountValidationAPI.Domain.Repositories;

namespace SortingCodeAccountValidationAPI.Repository
{
    public class ModulusWeightingRepository : IRepository<ModulusWeighting>
    {  
        /// <inheritdoc />
        public IEnumerable<ModulusWeighting> Where(Func<ModulusWeighting, bool> predicate)
        {
            return this.GetWeightings()
                .Where(predicate);
        }

        /// <summary>
        /// Gets the weightings from text file.
        /// </summary>
        /// <returns>A list of <see cref="ModulusWeighting"/>.</returns>
        private IEnumerable<ModulusWeighting> GetWeightings()
        {
            var response = new List<ModulusWeighting>();
            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var filePath = Path.Combine(directory, "valacdos.txt");

            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var segments = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                var weighting = new ModulusWeighting
                {
                    Start = Convert.ToInt32(segments[0]),
                    End = Convert.ToInt32(segments[1]),
                    ModCheck = (ModCheck)Enum.Parse(typeof(ModCheck), segments[2]),
                    Weights = segments.Skip(3).Take(14).Select(o => Convert.ToInt32(o)).ToArray(),
                    Exception = segments.Length == 18 ? Convert.ToInt32(segments[17]) : default(int?),
                };

                response.Add(weighting);
            }

            return response;
        }
    }
}
