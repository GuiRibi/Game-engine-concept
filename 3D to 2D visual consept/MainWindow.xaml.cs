using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _3D_to_2D_visual_consept
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Matrix matrix_A = new Matrix(2, 2, new double[] 
            {   
                0, 1,
                2, 3
            });
            Matrix matrix_B = new Matrix(2, 2, new double[] 
            { 
                1, 1, 
                1, 1
            });

            Matrix_Operations operation = new Matrix_Operations();
            double[] result = operation.Dot_Product(matrix_A, matrix_B);

            matrix_A.Print();
        }
    }
}