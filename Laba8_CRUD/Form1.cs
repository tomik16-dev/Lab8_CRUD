using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Laba8_CRUD
{
    public partial class Form1 : Form
    {
        private string connectionString = @"Server=KOMP-TEDDY;Database=StudentDB;Trusted_Connection=True;TrustServerCertificate=True;";
        private DataTable table = new DataTable();
        private int selectedId = -1;   // Id выбранного студента (-1 = никто не выбран)

        public Form1()
        {
            InitializeComponent();
            dataGridViewStudents.SelectionChanged += dataGridViewStudents_SelectionChanged;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            ClearFields();
        }
        // ---------- READ ----------
        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter(
                        "SELECT Id, FullName, GroupName, Age, AverageGrade FROM Students ORDER BY Id", conn);
                    table = new DataTable();
                    da.Fill(table);
                }
                dataGridViewStudents.DataSource = table;
                labelStatus.Text = "Всего студентов: " + table.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Очистка полей ввода
        private void ClearFields()
        {
            selectedId = -1;
            textBoxName.Clear();
            textBoxGroup.Clear();
            numericAge.Value = numericAge.Minimum;
            numericGrade.Value = numericGrade.Minimum;
            dataGridViewStudents.ClearSelection();
        }

        // Проверка данных перед отправкой в БД
        private bool ValidateInput()
        {
            if (textBoxName.Text.Trim() == "")
            {
                MessageBox.Show("Введите ФИО!", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (textBoxGroup.Text.Trim() == "")
            {
                MessageBox.Show("Введите группу!", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // Подставляем число в NumericUpDown, не выходя за его границы
        private void SetNumeric(NumericUpDown n, decimal value)
        {
            if (value < n.Minimum) value = n.Minimum;
            if (value > n.Maximum) value = n.Maximum;
            n.Value = value;
        }

        // Выбор строки — данные идут в поля формы
        private void dataGridViewStudents_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewStudents.SelectedRows.Count == 0) return;

            try
            {
                DataGridViewRow row = dataGridViewStudents.SelectedRows[0];
                selectedId = Convert.ToInt32(row.Cells["Id"].Value);
                textBoxName.Text = row.Cells["FullName"].Value.ToString();
                textBoxGroup.Text = row.Cells["GroupName"].Value.ToString();
                SetNumeric(numericAge, Convert.ToDecimal(row.Cells["Age"].Value));
                SetNumeric(numericGrade, Convert.ToDecimal(row.Cells["AverageGrade"].Value));
            }
            catch
            {
                // если в ячейке пусто (NULL) — просто ничего не делаем
            }
        }

        // ---------- CREATE ----------
        private void buttonAdd_Click_1(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Самостоятельное задание: проверяем, нет ли такого студента
                    SqlCommand check = new SqlCommand(
                        "SELECT COUNT(*) FROM Students WHERE FullName = @name", conn);
                    check.Parameters.AddWithValue("@name", textBoxName.Text.Trim());
                    int count = (int)check.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Студент с таким ФИО уже есть!", "Предупреждение",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Students (FullName, GroupName, Age, AverageGrade) " +
                        "VALUES (@name, @group, @age, @grade)", conn);
                    cmd.Parameters.AddWithValue("@name", textBoxName.Text.Trim());
                    cmd.Parameters.AddWithValue("@group", textBoxGroup.Text.Trim());
                    cmd.Parameters.AddWithValue("@age", (int)numericAge.Value);
                    cmd.Parameters.AddWithValue("@grade", numericGrade.Value);
                    cmd.ExecuteNonQuery();
                }

                LoadData();
                ClearFields();
                MessageBox.Show("Студент добавлен!", "Готово");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // ---------- UPDATE ----------
        private void buttonUpdate_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Сначала выберите студента в таблице!", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Берем ID прямо из выделенной строки
            int currentId = Convert.ToInt32(dataGridViewStudents.SelectedRows[0].Cells["Id"].Value);

            if (!ValidateInput()) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE Students SET FullName = @name, GroupName = @group, " +
                        "Age = @age, AverageGrade = @grade WHERE Id = @id", conn);
                    cmd.Parameters.AddWithValue("@name", textBoxName.Text.Trim());
                    cmd.Parameters.AddWithValue("@group", textBoxGroup.Text.Trim());
                    cmd.Parameters.AddWithValue("@age", (int)numericAge.Value);
                    cmd.Parameters.AddWithValue("@grade", numericGrade.Value);
                    cmd.Parameters.AddWithValue("@id", currentId); // Используем ID, взятый из таблицы
                    cmd.ExecuteNonQuery();
                }

                LoadData();
                ClearFields();
                MessageBox.Show("Данные обновлены!", "Готово");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка обновления: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // ---------- DELETE ----------
        private void buttonDelete_Click_1(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Сначала выберите студента в таблице!", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Удалить студента " + textBoxName.Text + "?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Students WHERE Id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", selectedId);
                    cmd.ExecuteNonQuery();
                }

                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка удаления: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // ---------- Очистить ----------
        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        // ------------ Отмена -----------
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            LoadData();      // перезагружаем таблицу из БД
            ClearFields();   // и очищаем поля
        }
        // ---------- Самостоятельно: Экспорт в CSV ----------
        private void buttonExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "CSV файлы (*.csv)|*.csv";
            dialog.FileName = "students.csv";

            if (dialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                using (StreamWriter writer = new StreamWriter(dialog.FileName, false, Encoding.UTF8))
                {
                    // заголовки столбцов
                    string[] headers = new string[table.Columns.Count];
                    for (int i = 0; i < table.Columns.Count; i++)
                        headers[i] = table.Columns[i].ColumnName;
                    writer.WriteLine(string.Join(";", headers));

                    // строки
                    foreach (DataRow row in table.Rows)
                    {
                        string[] values = new string[table.Columns.Count];
                        for (int i = 0; i < table.Columns.Count; i++)
                            values[i] = row[i].ToString().Replace(";", ",");
                        writer.WriteLine(string.Join(";", values));
                    }
                }
                MessageBox.Show("Таблица сохранена в файл!", "Готово");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка экспорта: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
