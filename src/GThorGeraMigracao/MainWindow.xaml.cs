namespace GThorGeraMigracao
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            DataContext = new MainWindowModel();
            InitializeComponent();
        }
    }
}
