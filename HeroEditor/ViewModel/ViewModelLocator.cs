/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:HeroEditor"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using HeroEditor.Model;
using HeroEditor.Service;
using HeroEditor.Service.DataBases;
using HeroEditor.Service.DataBases.Xml;
using Microsoft.Practices.ServiceLocation;
using System.Windows;

namespace HeroEditor.ViewModel
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
            
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ConnectionToOwnTinyFileBd>();
            SimpleIoc.Default.Register<IConnectionBd>( ()=>
            {
                return SimpleIoc.Default.GetInstance<ConnectionToOwnTinyFileBd>();
            });
            SimpleIoc.Default.Register<IXmlParserItem>(() =>
            {
                return new GetItemFromXml();
            });
            SimpleIoc.Default.Register<GrabberXmlItemsFromFolder>();
            SimpleIoc.Default.Register<ChoiceItemsControlViewModel>();
            SimpleIoc.Default.Register<HeroViewModel>();
            SimpleIoc.Default.Register<HeroModel>( () =>
            {
                return HolderHeroModel.Hero;
            });
            SimpleIoc.Default.Register<ChoosingHeroViewModel>();
            SimpleIoc.Default.Register<IXmlParserHero, ParserHero>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public ChoiceItemsControlViewModel ChoiceItemsControl
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ChoiceItemsControlViewModel>();
            }
        }

        public HeroViewModel Hero
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HeroViewModel>();
            }
        }

        public ChoosingHeroViewModel ChoosingHero
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ChoosingHeroViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}