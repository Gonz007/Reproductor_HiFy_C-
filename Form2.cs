using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Reproductor
{
    public partial class Form2 : Form
    {
        private Form1 form1;
        private List<string> folderPaths;  // Declaración de la variable miembro folderPaths

        public Form2(Form1 form1)
        {
            this.form1 = form1;
            this.folderPaths = new List<string>(form1.GetFolderPaths()); // Copiamos las rutas de form1 a la lista temporal
            InitializeComponent();
            LoadFolderPathsToCheckedListBox();

            // Deshabilitar botones si no hay elementos en la lista
            if (checkedListBox1.Items.Count == 0)
            {
                button4.Enabled = false; // Restaurar
                button3.Enabled = false; // Eliminar seleccion
            }
        }
        private void button5_Click(object sender, EventArgs e) //Agregar
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string folderPath = folderBrowserDialog1.SelectedPath;

                // Verificar si la lista ya contiene la ruta
                if (!folderPaths.Contains(folderPath))  // Cambiamos form1.GetFolderPaths() por folderPaths
                {
                    // Si no la contiene, agrega la ruta de la carpeta a la lista temporal
                    folderPaths.Add(folderPath);

                    // Agrega la ruta de la carpeta a la lista en Form2
                    checkedListBox1.Items.Add(folderPath);

                    // Habilitar botones
                    button4.Enabled = true; // Restaurar
                    button3.Enabled = true; // Eliminar seleccion
                }
            }
        }
        private void button3_Click(object sender, EventArgs e) //Eliminar seleccion
        {
            // Crear una lista para almacenar los índices de los elementos seleccionados.
            List<int> selectedIndices = new List<int>();

            // Llenar selectedIndices con los índices de los elementos seleccionados en checkedListBox1
            foreach (int index in checkedListBox1.CheckedIndices)
            {
                selectedIndices.Add(index);
            }

            for (int i = selectedIndices.Count - 1; i >= 0; i--)
            {
                checkedListBox1.Items.RemoveAt(selectedIndices[i]);
                folderPaths.RemoveAt(selectedIndices[i]);
            }
        }
        private void button4_Click(object sender, EventArgs e) //Restaurar
        {
            var confirmation = MessageBox.Show("¿Estás seguro que quieres eliminar todas las rutas?",
                                       "Quieto",
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Question);

            // Si el usuario presiona "Sí"
            if (confirmation == DialogResult.Yes)
            {
                // Vacía la lista temporal
                folderPaths.Clear();

                // Vacia la lista en Form2
                checkedListBox1.Items.Clear();
            }
        }
        private void button1_Click(object sender, EventArgs e)//Aplicar Y cerrar
        {
            form1.SetFolderPaths(folderPaths); // Actualiza la lista de rutas en Form1
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e) //Cancelar
        {
            this.Close();
        }
        private void LoadFolderPathsToCheckedListBox()//Lista de rutas
        {
            List<string> folderPaths = form1.GetFolderPaths();
            foreach (string folderPath in folderPaths)
            {
                checkedListBox1.Items.Add(folderPath);
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)//Actualiza los archivos en form1
        {
            base.OnFormClosing(e);
            form1.LoadFolderPaths();
        }
    }
}
