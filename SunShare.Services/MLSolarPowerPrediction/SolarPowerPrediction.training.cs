﻿// This file was auto-generated by ML.NET Model Builder.
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers.FastTree;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms;
using Microsoft.ML;

namespace SunShare_Services
{
    public partial class SolarPowerPrediction
    {
        public const string RetrainFilePath =  @"C:\Users\PICHAU\Downloads\BigML_Dataset_5f50a4cc0d052e40e6000034.csv";
        public const char RetrainSeparatorChar = ',';
        public const bool RetrainHasHeader =  true;

         /// <summary>
        /// Train a new model with the provided dataset.
        /// </summary>
        /// <param name="outputModelPath">File path for saving the model. Should be similar to "C:\YourPath\ModelName.mlnet"</param>
        /// <param name="inputDataFilePath">Path to the data file for training.</param>
        /// <param name="separatorChar">Separator character for delimited training file.</param>
        /// <param name="hasHeader">Boolean if training file has a header.</param>
        public static void Train(string outputModelPath, string inputDataFilePath = RetrainFilePath, char separatorChar = RetrainSeparatorChar, bool hasHeader = RetrainHasHeader)
        {
            var mlContext = new MLContext();

            var data = LoadIDataViewFromFile(mlContext, inputDataFilePath, separatorChar, hasHeader);
            var model = RetrainModel(mlContext, data);
            SaveModel(mlContext, model, data, outputModelPath);
        }

        /// <summary>
        /// Load an IDataView from a file path.
        /// </summary>
        /// <param name="mlContext">The common context for all ML.NET operations.</param>
        /// <param name="inputDataFilePath">Path to the data file for training.</param>
        /// <param name="separatorChar">Separator character for delimited training file.</param>
        /// <param name="hasHeader">Boolean if training file has a header.</param>
        /// <returns>IDataView with loaded training data.</returns>
        public static IDataView LoadIDataViewFromFile(MLContext mlContext, string inputDataFilePath, char separatorChar, bool hasHeader)
        {
            return mlContext.Data.LoadFromTextFile<ModelInput>(inputDataFilePath, separatorChar, hasHeader);
        }



        /// <summary>
        /// Save a model at the specified path.
        /// </summary>
        /// <param name="mlContext">The common context for all ML.NET operations.</param>
        /// <param name="model">Model to save.</param>
        /// <param name="data">IDataView used to train the model.</param>
        /// <param name="modelSavePath">File path for saving the model. Should be similar to "C:\YourPath\ModelName.mlnet.</param>
        public static void SaveModel(MLContext mlContext, ITransformer model, IDataView data, string modelSavePath)
        {
            // Pull the data schema from the IDataView used for training the model
            DataViewSchema dataViewSchema = data.Schema;

            using (var fs = File.Create(modelSavePath))
            {
                mlContext.Model.Save(model, dataViewSchema, fs);
            }
        }


        /// <summary>
        /// Retrains model using the pipeline generated as part of the training process.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <param name="trainData"></param>
        /// <returns></returns>
        public static ITransformer RetrainModel(MLContext mlContext, IDataView trainData)
        {
            var pipeline = BuildPipeline(mlContext);
            var model = pipeline.Fit(trainData);

            return model;
        }


        /// <summary>
        /// build the pipeline that is used from model builder. Use this function to retrain model.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <returns></returns>
        public static IEstimator<ITransformer> BuildPipeline(MLContext mlContext)
        {
            // Data process configuration with pipeline data transformations
            var pipeline = mlContext.Transforms.Categorical.OneHotEncoding(@"Is Daylight", @"Is Daylight", outputKind: OneHotEncodingEstimator.OutputKind.Indicator)      
                                    .Append(mlContext.Transforms.ReplaceMissingValues(new []{new InputOutputColumnPair(@"Day of Year", @"Day of Year"),new InputOutputColumnPair(@"Year", @"Year"),new InputOutputColumnPair(@"Month", @"Month"),new InputOutputColumnPair(@"Day", @"Day"),new InputOutputColumnPair(@"First Hour of Period", @"First Hour of Period"),new InputOutputColumnPair(@"Distance to Solar Noon", @"Distance to Solar Noon"),new InputOutputColumnPair(@"Average Temperature (Day)", @"Average Temperature (Day)"),new InputOutputColumnPair(@"Average Wind Direction (Day)", @"Average Wind Direction (Day)"),new InputOutputColumnPair(@"Average Wind Speed (Day)", @"Average Wind Speed (Day)"),new InputOutputColumnPair(@"Sky Cover", @"Sky Cover"),new InputOutputColumnPair(@"Visibility", @"Visibility"),new InputOutputColumnPair(@"Relative Humidity", @"Relative Humidity"),new InputOutputColumnPair(@"Average Wind Speed (Period)", @"Average Wind Speed (Period)"),new InputOutputColumnPair(@"Average Barometric Pressure (Period)", @"Average Barometric Pressure (Period)")}))      
                                    .Append(mlContext.Transforms.Concatenate(@"Features", new []{@"Is Daylight",@"Day of Year",@"Year",@"Month",@"Day",@"First Hour of Period",@"Distance to Solar Noon",@"Average Temperature (Day)",@"Average Wind Direction (Day)",@"Average Wind Speed (Day)",@"Sky Cover",@"Visibility",@"Relative Humidity",@"Average Wind Speed (Period)",@"Average Barometric Pressure (Period)"}))      
                                    .Append(mlContext.Regression.Trainers.FastForest(new FastForestRegressionTrainer.Options(){NumberOfTrees=9,NumberOfLeaves=19,FeatureFraction=0.9048345F,LabelColumnName=@"Power Generated",FeatureColumnName=@"Features"}));

            return pipeline;
        }
    }
 }