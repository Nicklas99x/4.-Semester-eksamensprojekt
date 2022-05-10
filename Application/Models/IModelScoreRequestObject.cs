using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public interface IModelScoreRequestObject
    {
        double ModelEvaluation { get; set; }
        float ModelPricePrediction { get; set; }
        ModelScoreRequestObject getModel();
    }
}
