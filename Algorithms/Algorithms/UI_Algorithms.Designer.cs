namespace Algorithms
{
    partial class UI_Algorithms
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl_algorithms = new System.Windows.Forms.TabControl();
            this.tabPage_sort = new System.Windows.Forms.TabPage();
            this.button_test = new System.Windows.Forms.Button();
            this.panel_heap = new System.Windows.Forms.Panel();
            this.button_min_heap = new System.Windows.Forms.Button();
            this.button_max_heap = new System.Windows.Forms.Button();
            this.checkBox_generate_int = new System.Windows.Forms.CheckBox();
            this.textBox_sort_time = new System.Windows.Forms.TextBox();
            this.label_sort_time = new System.Windows.Forms.Label();
            this.label_sort_check = new System.Windows.Forms.Label();
            this.textBox_sort_max_value = new System.Windows.Forms.TextBox();
            this.textBox_sort_input_length = new System.Windows.Forms.TextBox();
            this.comboBox_sort_algorithm = new System.Windows.Forms.ComboBox();
            this.button_sort = new System.Windows.Forms.Button();
            this.label_sort_algorithm = new System.Windows.Forms.Label();
            this.label_sort_max_value = new System.Windows.Forms.Label();
            this.label__sort_input_length = new System.Windows.Forms.Label();
            this.button__sort_generate_input = new System.Windows.Forms.Button();
            this.richTextBox__sort_output = new System.Windows.Forms.RichTextBox();
            this.richTextBox_sort_input = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl_algorithms.SuspendLayout();
            this.tabPage_sort.SuspendLayout();
            this.panel_heap.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl_algorithms
            // 
            this.tabControl_algorithms.Controls.Add(this.tabPage_sort);
            this.tabControl_algorithms.Controls.Add(this.tabPage2);
            this.tabControl_algorithms.Location = new System.Drawing.Point(12, 12);
            this.tabControl_algorithms.Name = "tabControl_algorithms";
            this.tabControl_algorithms.SelectedIndex = 0;
            this.tabControl_algorithms.Size = new System.Drawing.Size(776, 426);
            this.tabControl_algorithms.TabIndex = 0;
            // 
            // tabPage_sort
            // 
            this.tabPage_sort.Controls.Add(this.button_test);
            this.tabPage_sort.Controls.Add(this.panel_heap);
            this.tabPage_sort.Controls.Add(this.checkBox_generate_int);
            this.tabPage_sort.Controls.Add(this.textBox_sort_time);
            this.tabPage_sort.Controls.Add(this.label_sort_time);
            this.tabPage_sort.Controls.Add(this.label_sort_check);
            this.tabPage_sort.Controls.Add(this.textBox_sort_max_value);
            this.tabPage_sort.Controls.Add(this.textBox_sort_input_length);
            this.tabPage_sort.Controls.Add(this.comboBox_sort_algorithm);
            this.tabPage_sort.Controls.Add(this.button_sort);
            this.tabPage_sort.Controls.Add(this.label_sort_algorithm);
            this.tabPage_sort.Controls.Add(this.label_sort_max_value);
            this.tabPage_sort.Controls.Add(this.label__sort_input_length);
            this.tabPage_sort.Controls.Add(this.button__sort_generate_input);
            this.tabPage_sort.Controls.Add(this.richTextBox__sort_output);
            this.tabPage_sort.Controls.Add(this.richTextBox_sort_input);
            this.tabPage_sort.Location = new System.Drawing.Point(4, 22);
            this.tabPage_sort.Name = "tabPage_sort";
            this.tabPage_sort.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_sort.Size = new System.Drawing.Size(768, 400);
            this.tabPage_sort.TabIndex = 0;
            this.tabPage_sort.Text = "Сортировки";
            this.tabPage_sort.UseVisualStyleBackColor = true;
            // 
            // button_test
            // 
            this.button_test.Location = new System.Drawing.Point(343, 127);
            this.button_test.Name = "button_test";
            this.button_test.Size = new System.Drawing.Size(75, 23);
            this.button_test.TabIndex = 14;
            this.button_test.Text = "Тест";
            this.button_test.UseVisualStyleBackColor = true;
            this.button_test.Click += new System.EventHandler(this.button_test_Click);
            // 
            // panel_heap
            // 
            this.panel_heap.Controls.Add(this.button_min_heap);
            this.panel_heap.Controls.Add(this.button_max_heap);
            this.panel_heap.Location = new System.Drawing.Point(508, 13);
            this.panel_heap.Name = "panel_heap";
            this.panel_heap.Size = new System.Drawing.Size(249, 100);
            this.panel_heap.TabIndex = 13;
            // 
            // button_min_heap
            // 
            this.button_min_heap.Location = new System.Drawing.Point(19, 34);
            this.button_min_heap.Name = "button_min_heap";
            this.button_min_heap.Size = new System.Drawing.Size(153, 23);
            this.button_min_heap.TabIndex = 10;
            this.button_min_heap.Text = "Построить пирамиду (ну)";
            this.button_min_heap.UseVisualStyleBackColor = true;
            this.button_min_heap.Click += new System.EventHandler(this.button_min_heap_Click);
            // 
            // button_max_heap
            // 
            this.button_max_heap.Location = new System.Drawing.Point(19, 7);
            this.button_max_heap.Name = "button_max_heap";
            this.button_max_heap.Size = new System.Drawing.Size(153, 23);
            this.button_max_heap.TabIndex = 10;
            this.button_max_heap.Text = "Построить пирамиду (нв)";
            this.button_max_heap.UseVisualStyleBackColor = true;
            this.button_max_heap.Click += new System.EventHandler(this.button_max_heap_Click);
            // 
            // checkBox_generate_int
            // 
            this.checkBox_generate_int.AutoSize = true;
            this.checkBox_generate_int.Location = new System.Drawing.Point(283, 53);
            this.checkBox_generate_int.Name = "checkBox_generate_int";
            this.checkBox_generate_int.Size = new System.Drawing.Size(98, 17);
            this.checkBox_generate_int.TabIndex = 12;
            this.checkBox_generate_int.Text = "Только целые";
            this.checkBox_generate_int.UseVisualStyleBackColor = true;
            // 
            // textBox_sort_time
            // 
            this.textBox_sort_time.Location = new System.Drawing.Point(639, 135);
            this.textBox_sort_time.Name = "textBox_sort_time";
            this.textBox_sort_time.Size = new System.Drawing.Size(121, 20);
            this.textBox_sort_time.TabIndex = 9;
            // 
            // label_sort_time
            // 
            this.label_sort_time.AutoSize = true;
            this.label_sort_time.Location = new System.Drawing.Point(524, 138);
            this.label_sort_time.Name = "label_sort_time";
            this.label_sort_time.Size = new System.Drawing.Size(105, 13);
            this.label_sort_time.TabIndex = 8;
            this.label_sort_time.Text = "Время выполнения";
            // 
            // label_sort_check
            // 
            this.label_sort_check.AutoSize = true;
            this.label_sort_check.Location = new System.Drawing.Point(672, 372);
            this.label_sort_check.Name = "label_sort_check";
            this.label_sort_check.Size = new System.Drawing.Size(85, 13);
            this.label_sort_check.TabIndex = 7;
            this.label_sort_check.Text = "Отсортировано";
            // 
            // textBox_sort_max_value
            // 
            this.textBox_sort_max_value.Location = new System.Drawing.Point(122, 51);
            this.textBox_sort_max_value.Name = "textBox_sort_max_value";
            this.textBox_sort_max_value.Size = new System.Drawing.Size(121, 20);
            this.textBox_sort_max_value.TabIndex = 6;
            this.textBox_sort_max_value.Text = "1000";
            // 
            // textBox_sort_input_length
            // 
            this.textBox_sort_input_length.Location = new System.Drawing.Point(122, 18);
            this.textBox_sort_input_length.Name = "textBox_sort_input_length";
            this.textBox_sort_input_length.Size = new System.Drawing.Size(121, 20);
            this.textBox_sort_input_length.TabIndex = 6;
            this.textBox_sort_input_length.Text = "10";
            // 
            // comboBox_sort_algorithm
            // 
            this.comboBox_sort_algorithm.FormattingEnabled = true;
            this.comboBox_sort_algorithm.Location = new System.Drawing.Point(343, 15);
            this.comboBox_sort_algorithm.Name = "comboBox_sort_algorithm";
            this.comboBox_sort_algorithm.Size = new System.Drawing.Size(121, 21);
            this.comboBox_sort_algorithm.TabIndex = 5;
            // 
            // button_sort
            // 
            this.button_sort.Location = new System.Drawing.Point(343, 90);
            this.button_sort.Name = "button_sort";
            this.button_sort.Size = new System.Drawing.Size(90, 23);
            this.button_sort.TabIndex = 4;
            this.button_sort.Text = "Сортировать";
            this.button_sort.UseVisualStyleBackColor = true;
            this.button_sort.Click += new System.EventHandler(this.button_sort_Click);
            // 
            // label_sort_algorithm
            // 
            this.label_sort_algorithm.AutoSize = true;
            this.label_sort_algorithm.Location = new System.Drawing.Point(280, 18);
            this.label_sort_algorithm.Name = "label_sort_algorithm";
            this.label_sort_algorithm.Size = new System.Drawing.Size(56, 13);
            this.label_sort_algorithm.TabIndex = 3;
            this.label_sort_algorithm.Text = "Алгоритм";
            // 
            // label_sort_max_value
            // 
            this.label_sort_max_value.AutoSize = true;
            this.label_sort_max_value.Location = new System.Drawing.Point(15, 54);
            this.label_sort_max_value.Name = "label_sort_max_value";
            this.label_sort_max_value.Size = new System.Drawing.Size(87, 13);
            this.label_sort_max_value.TabIndex = 3;
            this.label_sort_max_value.Text = "Макс. значение";
            // 
            // label__sort_input_length
            // 
            this.label__sort_input_length.AutoSize = true;
            this.label__sort_input_length.Location = new System.Drawing.Point(15, 20);
            this.label__sort_input_length.Name = "label__sort_input_length";
            this.label__sort_input_length.Size = new System.Drawing.Size(40, 13);
            this.label__sort_input_length.TabIndex = 3;
            this.label__sort_input_length.Text = "Длина";
            // 
            // button__sort_generate_input
            // 
            this.button__sort_generate_input.Location = new System.Drawing.Point(122, 90);
            this.button__sort_generate_input.Name = "button__sort_generate_input";
            this.button__sort_generate_input.Size = new System.Drawing.Size(90, 23);
            this.button__sort_generate_input.TabIndex = 1;
            this.button__sort_generate_input.Text = "Генерировать";
            this.button__sort_generate_input.UseVisualStyleBackColor = true;
            this.button__sort_generate_input.Click += new System.EventHandler(this.button_generate_input_Click);
            // 
            // richTextBox__sort_output
            // 
            this.richTextBox__sort_output.Location = new System.Drawing.Point(18, 273);
            this.richTextBox__sort_output.Name = "richTextBox__sort_output";
            this.richTextBox__sort_output.Size = new System.Drawing.Size(744, 96);
            this.richTextBox__sort_output.TabIndex = 0;
            this.richTextBox__sort_output.Text = "";
            // 
            // richTextBox_sort_input
            // 
            this.richTextBox_sort_input.Location = new System.Drawing.Point(18, 171);
            this.richTextBox_sort_input.Name = "richTextBox_sort_input";
            this.richTextBox_sort_input.Size = new System.Drawing.Size(744, 96);
            this.richTextBox_sort_input.TabIndex = 0;
            this.richTextBox_sort_input.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 400);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // UI_Algorithms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl_algorithms);
            this.Name = "UI_Algorithms";
            this.Text = "Алгоритмы";
            this.tabControl_algorithms.ResumeLayout(false);
            this.tabPage_sort.ResumeLayout(false);
            this.tabPage_sort.PerformLayout();
            this.panel_heap.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl_algorithms;
        private System.Windows.Forms.TabPage tabPage_sort;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox comboBox_sort_algorithm;
        private System.Windows.Forms.Button button_sort;
        private System.Windows.Forms.Label label_sort_algorithm;
        private System.Windows.Forms.Label label__sort_input_length;
        private System.Windows.Forms.Button button__sort_generate_input;
        private System.Windows.Forms.RichTextBox richTextBox__sort_output;
        private System.Windows.Forms.RichTextBox richTextBox_sort_input;
        private System.Windows.Forms.TextBox textBox_sort_input_length;
        private System.Windows.Forms.Label label_sort_check;
        private System.Windows.Forms.Label label_sort_time;
        private System.Windows.Forms.TextBox textBox_sort_time;
        private System.Windows.Forms.TextBox textBox_sort_max_value;
        private System.Windows.Forms.Label label_sort_max_value;
        private System.Windows.Forms.Button button_max_heap;
        private System.Windows.Forms.CheckBox checkBox_generate_int;
        private System.Windows.Forms.Panel panel_heap;
        private System.Windows.Forms.Button button_min_heap;
        private System.Windows.Forms.Button button_test;
    }
}

