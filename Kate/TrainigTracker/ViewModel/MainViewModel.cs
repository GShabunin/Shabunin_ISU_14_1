using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MahApps.Metro.Controls;
using TrainigTracker.view;
using System;

namespace TrainigTracker.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
        }

        
        
             private RelayCommand<MetroWindow> _openCreateNewTrainingWindow;
        public RelayCommand<MetroWindow> OpenCreateNewTrainingWindow
        {
            get
            {
                if (_openCreateNewTrainingWindow == null)
                {
                    _openCreateNewTrainingWindow = new RelayCommand<MetroWindow>(ExecuteOpenCreateNewTrainingWindow);
                }
                return _openCreateNewTrainingWindow;
            }
            set
            {
                _openCreateNewTrainingWindow = value;
            }
        }

        private void ExecuteOpenCreateNewTrainingWindow(MetroWindow mainWindow)
        {
            if (mainWindow == null) throw new ArgumentNullException("mainWindow");

                CreateNewTraining window = new CreateNewTraining();
          window.Show();
          mainWindow.Close();
        }

        private RelayCommand<MetroWindow> _openLoadTrainingWindow;
        public RelayCommand<MetroWindow> OpenLoadTrainingWindow
        {
            get
            {
                if (_openLoadTrainingWindow == null)
                {
                    _openLoadTrainingWindow = new RelayCommand<MetroWindow>(ExecuteOpenWindowLoadTrainingWindow);
                }
                return _openLoadTrainingWindow;
            }
            private set
            {
                _openLoadTrainingWindow = value;
            }
        }

        private void ExecuteOpenWindowLoadTrainingWindow(MetroWindow mainWindow)
        {
            if (mainWindow == null) throw new ArgumentNullException("mainWindow");

           LoadTraining w = new LoadTraining();
           w.Show();
           mainWindow.Close();

        }

        }
    }
