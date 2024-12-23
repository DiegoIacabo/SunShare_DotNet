﻿// This file was auto-generated by ML.NET Model Builder.
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
namespace SunShare_Services
{
    public partial class SolarPowerPrediction
    {
        /// <summary>
        /// model input class for SolarPowerPrediction.
        /// </summary>
        #region model input class
        public class ModelInput
        {
            [LoadColumn(0)]
            [ColumnName(@"Day of Year")]
            public float Day_of_Year { get; set; }

            [LoadColumn(1)]
            [ColumnName(@"Year")]
            public float Year { get; set; }

            [LoadColumn(2)]
            [ColumnName(@"Month")]
            public float Month { get; set; }

            [LoadColumn(3)]
            [ColumnName(@"Day")]
            public float Day { get; set; }

            [LoadColumn(4)]
            [ColumnName(@"First Hour of Period")]
            public float First_Hour_of_Period { get; set; }

            [LoadColumn(5)]
            [ColumnName(@"Is Daylight")]
            public bool Is_Daylight { get; set; }

            [LoadColumn(6)]
            [ColumnName(@"Distance to Solar Noon")]
            public float Distance_to_Solar_Noon { get; set; }

            [LoadColumn(7)]
            [ColumnName(@"Average Temperature (Day)")]
            public float Average_Temperature__Day_ { get; set; }

            [LoadColumn(8)]
            [ColumnName(@"Average Wind Direction (Day)")]
            public float Average_Wind_Direction__Day_ { get; set; }

            [LoadColumn(9)]
            [ColumnName(@"Average Wind Speed (Day)")]
            public float Average_Wind_Speed__Day_ { get; set; }

            [LoadColumn(10)]
            [ColumnName(@"Sky Cover")]
            public float Sky_Cover { get; set; }

            [LoadColumn(11)]
            [ColumnName(@"Visibility")]
            public float Visibility { get; set; }

            [LoadColumn(12)]
            [ColumnName(@"Relative Humidity")]
            public float Relative_Humidity { get; set; }

            [LoadColumn(13)]
            [ColumnName(@"Average Wind Speed (Period)")]
            public float Average_Wind_Speed__Period_ { get; set; }

            [LoadColumn(14)]
            [ColumnName(@"Average Barometric Pressure (Period)")]
            public float Average_Barometric_Pressure__Period_ { get; set; }

            [LoadColumn(15)]
            [ColumnName(@"Power Generated")]
            public float Power_Generated { get; set; }

        }

        #endregion

        /// <summary>
        /// model output class for SolarPowerPrediction.
        /// </summary>
        #region model output class
        public class ModelOutput
        {
            [ColumnName(@"Day of Year")]
            public float Day_of_Year { get; set; }

            [ColumnName(@"Year")]
            public float Year { get; set; }

            [ColumnName(@"Month")]
            public float Month { get; set; }

            [ColumnName(@"Day")]
            public float Day { get; set; }

            [ColumnName(@"First Hour of Period")]
            public float First_Hour_of_Period { get; set; }

            [ColumnName(@"Is Daylight")]
            public float[] Is_Daylight { get; set; }

            [ColumnName(@"Distance to Solar Noon")]
            public float Distance_to_Solar_Noon { get; set; }

            [ColumnName(@"Average Temperature (Day)")]
            public float Average_Temperature__Day_ { get; set; }

            [ColumnName(@"Average Wind Direction (Day)")]
            public float Average_Wind_Direction__Day_ { get; set; }

            [ColumnName(@"Average Wind Speed (Day)")]
            public float Average_Wind_Speed__Day_ { get; set; }

            [ColumnName(@"Sky Cover")]
            public float Sky_Cover { get; set; }

            [ColumnName(@"Visibility")]
            public float Visibility { get; set; }

            [ColumnName(@"Relative Humidity")]
            public float Relative_Humidity { get; set; }

            [ColumnName(@"Average Wind Speed (Period)")]
            public float Average_Wind_Speed__Period_ { get; set; }

            [ColumnName(@"Average Barometric Pressure (Period)")]
            public float Average_Barometric_Pressure__Period_ { get; set; }

            [ColumnName(@"Power Generated")]
            public float Power_Generated { get; set; }

            [ColumnName(@"Features")]
            public float[] Features { get; set; }

            [ColumnName(@"Score")]
            public float Score { get; set; }

        }

        #endregion

        private static string MLNetModelPath = Path.GetFullPath("SolarPowerPrediction.mlnet");

        public static readonly Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>(() => CreatePredictEngine(), true);


        private static PredictionEngine<ModelInput, ModelOutput> CreatePredictEngine()
        {
            var mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load(MLNetModelPath, out var _);
            return mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
        }

        /// <summary>
        /// Use this method to predict on <see cref="ModelInput"/>.
        /// </summary>
        /// <param name="input">model input.</param>
        /// <returns><seealso cref=" ModelOutput"/></returns>
        public static ModelOutput Predict(ModelInput input)
        {
            var predEngine = PredictEngine.Value;
            return predEngine.Predict(input);
        }

    }
}
