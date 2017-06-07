using MyERP.Infarastucture;
using MyERP.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyERP.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        Profession _currentProffession;
        
        public Profession CurrentProfession
        {
            get
            {
                if (_currentProffession == null)
                    _currentProffession = new Profession();
                return _currentProffession;
            }
            set
            {
                _currentProffession = value;
                OnPropertyChanged("CurrentProfession");
            }
        }

        ObservableCollection<Profession> _professions;

        public ObservableCollection<Profession> Professions
        {
            get
            {
                if (_professions == null)
                    _professions = ProfessionRepository.AllProfessions;
                return _professions;
            }
        }

        

        RelayCommand _addProfessionCommand;
        public ICommand AddClient
        {
            get
            {
                if (_addProfessionCommand == null)
                    _addProfessionCommand = new RelayCommand(ExecuteAddProfessionCommand, CanExecuteAddProfessionCommand);
                return _addProfessionCommand;
            }
        }

        public void ExecuteAddProfessionCommand(object parameter)
        {
            Professions.Add(CurrentProfession);
            CurrentProfession = null;
        }

        public bool CanExecuteAddProfessionCommand(object parameter)
        {
            return true;
        }


        RelayCommand _deleteProfessionCommand;

        public ICommand DeleteProfession
        {
            get
            {
                if (_deleteProfessionCommand == null)
                    _deleteProfessionCommand = new RelayCommand(ExecuteDeleteProfessionCommand, CanExecuteDeleteProfessionCommand);
                return _deleteProfessionCommand;
            }
        }

        public void ExecuteDeleteProfessionCommand(object parameter)
        {
            Professions.Remove(CurrentProfession);
            CurrentProfession = null;
        }

        public bool CanExecuteDeleteProfessionCommand(object parameter)
        {
            return true;
        }


        protected override void OnDispose()
        {
            this.Professions.Clear();
        }
    }
}
