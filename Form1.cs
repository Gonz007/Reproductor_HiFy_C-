using NAudio.Wave;
using System.Diagnostics;
using TagFile = TagLib.File;
using System.Drawing.Drawing2D;
namespace Reproductor
{
    public partial class Form1 : Form
    {
        private IWavePlayer wavePlayer;
        private WaveStream audioFileReader;
        private List<string> filePaths = new List<string>();
        private int currentSongIndex = 0;
        private ToolTip toolTip;
        private System.Windows.Forms.Timer playbackPositionUpdateTimer;
        private bool trackBarIsDragging = false;
        private float volume = 0.5f;
        private Color dominantColor1;
        private Color dominantColor2;
        public Form1()
        {
            InitializeComponent();
            // Agregar el controlador de eventos TextChanged al elemento textBox1
            textBox1.TextChanged += textBox1_TextChanged;
            RefreshSongPaths();
            // Agregar el controlador de eventos CheckedChanged al elemento checkBox2
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;

            //Esta parte es para que en el buscador aparezca en gris el buscar
            textBox1.Enter += textBox1_Enter;
            textBox1.Leave += textBox1_Leave;
            textBox1.Text = "Buscar...";
            textBox1.ForeColor = Color.Gray;

            // Cargar las rutas de las carpetas guardadas previamente y el volumen
            LoadVolume();
            LoadFolderPaths();
            playbackPositionUpdateTimer = new System.Windows.Forms.Timer { Interval = 1000 };

            trackBar1.ValueChanged += trackBar1_ValueChanged;
            trackBar1.MouseDown += (s, e) => trackBarIsDragging = true;
            trackBar1.MouseUp += (s, e) => trackBarIsDragging = false;
            wavePlayer = new WaveOutEvent();
            wavePlayer.PlaybackStopped += wavePlayer_PlaybackStopped;

            trackBar2.ValueChanged += trackBar2_ValueChanged;

            trackBar2.Minimum = 0;
            trackBar2.Maximum = 100;
            trackBar2.Value = (int)(volume * 100);  // Convertir el volumen a la escala del trackBar2


        }


        private List<string> folderPaths = new List<string>();

        

        public void SetFolderPaths(List<string> newPaths)
        {
            // Asume que 'folderPaths' es la lista que estás utilizando en Form1 para guardar las rutas.
            folderPaths.Clear();
            folderPaths.AddRange(newPaths);

            // Actualiza el archivo folderPaths.txt para reflejar los cambios
            System.IO.File.WriteAllLines("folderPaths.txt", folderPaths);
        }
        public void AddFolderPath(string folderPath)
        {
            folderPaths.Add(folderPath);
            System.IO.File.WriteAllLines("folderPaths.txt", folderPaths);
        }
        public void RemoveFolderPathAt(int index)
        {
            if (index >= 0 && index < folderPaths.Count)
            {
                folderPaths.RemoveAt(index);
            }
            System.IO.File.WriteAllLines("folderPaths.txt", folderPaths);
        }
        public void LoadFolderPaths()
        {
            if (System.IO.File.Exists("folderPaths.txt"))
            {
                string[] paths = System.IO.File.ReadAllLines("folderPaths.txt");
                folderPaths = new List<string>(paths);
                LoadSongsFromFolderPaths();
            }
        }
        private void LoadSongsFromFolderPaths()
        {
            filePaths.Clear();
            string[] fileExtensions = new string[] { "*.mp3", "*.flac", "*.wav" };
            foreach (string folderPath in folderPaths)
            {
                if (!String.IsNullOrEmpty(folderPath) && Directory.Exists(folderPath))
                {
                    foreach (var extension in fileExtensions)
                    {
                        string[] filesInFolder = Directory.GetFiles(folderPath, extension, SearchOption.AllDirectories);
                        filePaths.AddRange(filesInFolder);
                    }
                }
            }

            lstFiles.Items.Clear();
            lstFiles.Items.AddRange(filePaths.Select(Path.GetFileName).ToArray());

            // Habilitar botones
            btnPlay.Enabled = true;
            btnNext.Enabled = true;
            btnPrevious.Enabled = true;
            LoadVolume();
            trackBar2.Minimum = 0;
            trackBar2.Maximum = 100;

            trackBar2.Value = (int)(volume * 100);
        }
        public List<string> GetFolderPaths()
        {
            return folderPaths;
        }
        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            volume = trackBar2.Value / 100f;  // Convertir el valor del trackBar2 a la escala de volumen
            if (audioFileReader != null)
            {
                ((AudioFileReader)audioFileReader).Volume = volume;
            }
            // Guardar el volumen actual
            Properties.Settings.Default.Volume = volume;
            Properties.Settings.Default.Save();
        }
        private void LoadVolume()
        {
            if (Properties.Settings.Default.Volume != -1)
            {
                volume = Properties.Settings.Default.Volume;
                if (volume < 0) volume = 0; // Verificar que el valor no sea menor que el mínimo permitido
                if (volume > 1) volume = 1; // Verificar que el valor no sea mayor que el máximo permitido
                trackBar2.Minimum = 0;
                trackBar2.Maximum = 100;
                trackBar2.Value = (int)(volume * 100);
            }
        }
        private void RefreshSongPaths()
        {
            for (int i = filePaths.Count - 1; i >= 0; i--)
            {
                if (!System.IO.File.Exists(filePaths[i]))
                {
                    filePaths.RemoveAt(i);
                }
            }
        }
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (trackBarIsDragging)
            {
                if (audioFileReader != null)
                {
                    double trackBarRatio = trackBar1.Value / (double)trackBar1.Maximum;
                    double newTimeSec = trackBarRatio * audioFileReader.TotalTime.TotalSeconds;

                    audioFileReader.CurrentTime = TimeSpan.FromSeconds(newTimeSec);
                }
            }
        }
        private void ShuffleSongs()
        {
            var random = new Random();
            filePaths = filePaths.OrderBy(x => random.Next()).ToList();
        }
        public List<string> GetFilePaths()
        {
            return filePaths;
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();
        }
        public void AddFilePath(string folderpath)
        {
            filePaths.Add(folderpath);
            System.IO.File.WriteAllLines("folderPaths.txt", filePaths);
        }
        public void RemoveFilePathAt(int index)
        {
            // Elimina el archivo en el índice especificado de la lista filePaths.
            if (index >= 0 && index < filePaths.Count)
            {
                filePaths.RemoveAt(index);
            }

            // Actualiza el archivo folderPaths.txt.
            System.IO.File.WriteAllLines("folderPaths.txt", filePaths);
        }
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Buscar...")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "Buscar...";
                textBox1.ForeColor = Color.Gray;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox1.Text.ToLower();
            var filteredFiles = filePaths.Where(file => Path.GetFileName(file).ToLower().Contains(searchText)).ToList();
            lstFiles.Items.Clear();
            lstFiles.Items.AddRange(filteredFiles.Select(Path.GetFileName).ToArray());
        }
        private void wavePlayer_PlaybackStopped(object sender, StoppedEventArgs e)
        {

            if (audioFileReader != null && audioFileReader.CurrentTime.TotalSeconds >= audioFileReader.TotalTime.TotalSeconds - 1)
            {
                if (currentSongIndex + 1 < filePaths.Count)
                {
                    //Esta mierda me tomo como medio día solo para decirme si solo llamo un servicio que ya creé paa un boton, ajjajajajajajajajajajajajajaj
                    currentSongIndex++;
                    lstFiles.SelectedIndex = currentSongIndex;
                    PlayCurrentSong();
                }
            }
        }
        private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentSongIndex = lstFiles.SelectedIndex;
            PlayCurrentSong();
        }
        private void UpdateSongName()
        {
            label1.Text = Path.GetFileNameWithoutExtension(filePaths[currentSongIndex]);
        }
        private async void UpdatePlaybackPositionAsync()
        {
            while (wavePlayer != null && wavePlayer.PlaybackState == PlaybackState.Playing)
            {
                TimeSpan currentTime = audioFileReader.CurrentTime;
                TimeSpan totalTimeSpan = audioFileReader.TotalTime;

                string newText = $"{currentTime.ToString(@"mm\:ss")} / {totalTimeSpan.ToString(@"mm\:ss")}";

                if (!IsDisposed) // Verifica que el formulario todavía está cargado
                {
                    Invoke((MethodInvoker)delegate
                    {
                        label2.Text = newText;
                        if (!trackBarIsDragging)
                        {
                            int newValue = (int)currentTime.TotalSeconds;
                            if (newValue >= trackBar1.Minimum && newValue <= trackBar1.Maximum)
                            {
                                trackBar1.Value = newValue;
                            }
                        }
                        if (currentTime + TimeSpan.FromSeconds(-0.75) >= totalTimeSpan)
                        {
                            wavePlayer.Stop();
                            if (!checkBox2.Checked)
                            {
                                btnNext.PerformClick();
                            }
                        }
                    });
                }
                await Task.Delay(1000);
            }
        }
        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (currentSongIndex >= 0 && currentSongIndex < filePaths.Count)
            {
                if (wavePlayer == null)
                {
                    PlayCurrentSong();
                }
                else if (wavePlayer.PlaybackState == PlaybackState.Playing)
                {
                    wavePlayer.Pause();
                    btnPlay.Text = "▶️";
                }
                else if (wavePlayer.PlaybackState == PlaybackState.Paused)
                {
                    wavePlayer.Play();
                    btnPlay.Text = "⏹️";
                }
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentSongIndex + 1 < filePaths.Count)
            {
                currentSongIndex++;
                lstFiles.SelectedIndex = currentSongIndex;
                PlayCurrentSong();
            }
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (audioFileReader != null && audioFileReader.CurrentTime.TotalSeconds <= 4 && currentSongIndex - 1 >= 0)
            {
                currentSongIndex--;
            }
            lstFiles.SelectedIndex = currentSongIndex;
            PlayCurrentSong();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                ShuffleSongs();
                lstFiles.Items.Clear();
                lstFiles.Items.AddRange(filePaths.Select(Path.GetFileName).ToArray());
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (wavePlayer != null) // Si wavePlayer no es null, quita todos los controladores de eventos asociados
            {
                wavePlayer.PlaybackStopped -= wavePlayer_PlaybackStopped;
                wavePlayer.PlaybackStopped -= wavePlayer_PlaybackStopped_Repeat;
            }

            // Ahora, independientemente del estado de wavePlayer, se asignará el controlador de eventos correcto
            if (checkBox2.Checked)
            {
                wavePlayer.PlaybackStopped += wavePlayer_PlaybackStopped_Repeat;
            }
            else
            {
                wavePlayer.PlaybackStopped += wavePlayer_PlaybackStopped;
            }
        }
        private void wavePlayer_PlaybackStopped_Repeat(object sender, StoppedEventArgs e)
        {
            PlayCurrentSong();
        }
        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private async void PlayCurrentSong()
        {
            if (wavePlayer != null)
            {
                wavePlayer.Dispose();
                wavePlayer = null;
            }

            if (audioFileReader != null)
            {
                audioFileReader.Dispose();
                audioFileReader = null;
            }

            try
            {
                wavePlayer = new WaveOutEvent();
                audioFileReader = new AudioFileReader(filePaths[currentSongIndex]);
                ((AudioFileReader)audioFileReader).Volume = volume; // establecer el volumen aquí
                wavePlayer.Init(audioFileReader);
                wavePlayer.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al reproducir la canción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            btnPlay.Text = "⏹️";

            LoadAlbumArt();
            UpdateSongName();
            trackBar1.Minimum = 0;
            trackBar1.Maximum = (int)audioFileReader.TotalTime.TotalSeconds;
            trackBar1.TickFrequency = 1;  // Esto hace que haya un tick por cada segundo

            wavePlayer.PlaybackStopped += wavePlayer_PlaybackStopped;
            UpdatePlaybackPositionAsync();

            // Si wavePlayer está reproduciendo un archivo, espera hasta que termine
            while (wavePlayer != null && wavePlayer.PlaybackState == PlaybackState.Playing)
            {
                await Task.Delay(500);
            }
        }
        public (Color, Color) GetDominantColors(Image image)
        {
            var bitmap = new Bitmap(image);
            var colorPalette = GetColorPalette(bitmap, 2);
            return (colorPalette[0], colorPalette[1]);
        }


        private Color[] GetColorPalette(Bitmap bitmap, int count)
        {
            var colorHistogram = new Dictionary<Color, int>();
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    var color = bitmap.GetPixel(x, y);
                    if (colorHistogram.ContainsKey(color))
                        colorHistogram[color]++;
                    else
                        colorHistogram[color] = 1;
                }
            }

            var sortedColors = colorHistogram.OrderByDescending(pair => pair.Value).Select(pair => pair.Key).Take(count).ToArray();

            Console.WriteLine($"Dominant colors: {sortedColors[0]}, {sortedColors[1]}"); // Imprimir colores dominantes

            return sortedColors;
        }


        private void LoadAlbumArt()
        {
            try
            {
                using (var file = TagFile.Create(filePaths[currentSongIndex]))
                {
                    if (file.Tag.Pictures.Length > 0)
                    {
                        var imageData = file.Tag.Pictures[0].Data;
                        using (var ms = new MemoryStream(imageData.Data))
                        {
                            var albumArt = Image.FromStream(ms);
                            pictureSong.SizeMode = PictureBoxSizeMode.Zoom;

                            pictureSong.Image = albumArt;

                            // Aquí actualizamos los colores dominantes
                            var (color1, color2) = GetDominantColors(albumArt);
                            this.dominantColor1 = color1;
                            this.dominantColor2 = color2;
                            this.Invalidate(); // Forzamos a que se repinte el formulario
                        }
                    }
                    else
                    {
                        pictureSong.Image = null;
                        // Aquí eliges un par de colores por defecto cuando no hay imagen de portada
                        this.dominantColor1 = Color.Gray;
                        this.dominantColor2 = Color.DarkGray;
                        this.Invalidate();
                    }
                }
            }
            catch
            {
                pictureSong.Image = null;
                // Aquí eliges un par de colores por defecto cuando ocurre una excepción
                this.dominantColor1 = Color.Black;
                this.dominantColor2 = Color.DarkGray;
                this.Invalidate();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (currentSongIndex >= 0 && currentSongIndex < filePaths.Count)
            {
                string ruta_a_tu_cancion = filePaths[currentSongIndex];

                var coverArt = ExtractCoverArt(ruta_a_tu_cancion);
                if (coverArt != null)
                {
                    var (color1, color2) = GetDominantColors(coverArt);
                    this.dominantColor1 = color1;
                    this.dominantColor2 = color2;
                }
                else
                {
                    // Establecer un par de colores de fondo por defecto cuando no hay imagen de portada
                    this.dominantColor1 = Color.Gray;
                    this.dominantColor2 = Color.DarkGray;
                }
                this.Invalidate();
            }
        }



        public Image ExtractCoverArt(string filePath)
        {
            var file = TagLib.File.Create(filePath);
            var picture = file.Tag.Pictures.FirstOrDefault();
            if (picture != null)
            {
                using (var ms = new MemoryStream(picture.Data.Data))
                {
                    return Image.FromStream(ms);
                }
            }

            return null;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (var brush = new LinearGradientBrush(this.ClientRectangle, this.dominantColor1, this.dominantColor2, 90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

    }
}