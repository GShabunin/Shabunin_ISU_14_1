using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using HeroEditor.View.Windows;
using MahApps.Metro.Controls;
using System;

namespace HeroEditor.ViewModel
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
        #region Ctor
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {

        }
        #endregion

        #region Commands

        private RelayCommand<MetroWindow> _openChoosingHeroWindow;
        public RelayCommand<MetroWindow> OpenChoosingHeroWindow
        {
            get
            {
                if (_openChoosingHeroWindow == null)
                {
                    _openChoosingHeroWindow = new RelayCommand<MetroWindow>(ExecuteOpenChoosingHeroWindow);
                }
                return _openChoosingHeroWindow;
            }
            set
            {
                _openChoosingHeroWindow = value;
            }
        }

        private void ExecuteOpenChoosingHeroWindow(MetroWindow mainWindow)
        {
            if (mainWindow == null) throw new ArgumentNullException("mainWindow");

            ChoosingHeroWindow window = new ChoosingHeroWindow();
            window.Show();
            mainWindow.Close();
        }

        private RelayCommand<MetroWindow> _openWindowCreateNewHero;
        public RelayCommand<MetroWindow> OpenWindowCreateNewHero
        {
            get
            {
                if (_openWindowCreateNewHero == null)
                {
                    _openWindowCreateNewHero = new RelayCommand<MetroWindow>(ExecuteOpenWindowCreateNewHero);
                }
                return _openWindowCreateNewHero;
            }
            private set
            {
                _openWindowCreateNewHero = value;
            }
        }

        private void ExecuteOpenWindowCreateNewHero(MetroWindow mainWindow)
        {
            if (mainWindow == null) throw new ArgumentNullException("mainWindow");

            HeroEditorWindow w = new HeroEditorWindow();
            w.Show();
            mainWindow.Close();

        }

        #endregion

    }
}