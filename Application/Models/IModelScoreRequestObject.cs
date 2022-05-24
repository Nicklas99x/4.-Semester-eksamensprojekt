using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public interface IModelScoreRequestObject
    {
        //Inr´terface that contains a property of type double and a method
        //With the return parameter ModelScoreRequestObject
        double ModelEvaluation { get; set; }
        ModelScoreRequestObject GetModel();
    }
}
