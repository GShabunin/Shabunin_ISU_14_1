/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:TrainigTracker"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using TrainigTracker.Service;
using TrainigTracker.Models;
using TrainigTracker.Models.Exercises;
using System.Windows;

namespace TrainigTracker.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ConnectionToBD>();
            SimpleIoc.Default.Register<IConnectionBd>(() =>
            {
                return SimpleIoc.Default.GetInstance<ConnectionToBD>();
            });
            SimpleIoc.Default.Register<IXMLParserExercise>(() =>
            {
                return new GetExerciseFromXML();
            });
            SimpleIoc.Default.Register<XMLTrGrabber>();
           
            SimpleIoc.Default.Register<TrainingViewModel>();
            SimpleIoc.Default.Register<TrainingModel>(() =>
            {
                return TrainingHolder.Train;
            });
            SimpleIoc.Default.Register<LoadTrainigViewModel>();
            SimpleIoc.Default.Register<IXMLParserTraining, TrainingParser>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
    
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}