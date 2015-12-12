/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:TrainingTrackerV2"
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
using TrainingTrackerV2.DataBase;
using TrainingTrackerV2.DataBase.Xml;
using TrainingTrackerV2.MagicService;

namespace TrainingTrackerV2.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<StartViewModel>();
            SimpleIoc.Default.Register<AddNewTrainingViewModel>();

            //SimpleIoc.Default.Register<IDataBridge, DataBridge>();

            SimpleIoc.Default.Register<IDataBridge, FakeBridge>();
            SimpleIoc.Default.Register<IConnectionDb, ConnectionXml>();
        }

        public StartViewModel Start
        {
            get
            {
                return ServiceLocator.Current.GetInstance<StartViewModel>();
            }
        }

        public AddNewTrainingViewModel AddNewTraining
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddNewTrainingViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}