using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BlockBasedCSharpGenerator
{
    public enum Language
    {
        Russian,
        English
    }

    public static class Localization
    {
        public static Language CurrentLanguage { get; set; } = Language.Russian;

        private static readonly Dictionary<string, string> RussianStrings = new Dictionary<string, string>
        {
            ["MainFormTitle"] = "Генератор кода из блоков C#",
            ["AvailableBlocks"] = "Доступные блоки",
            ["Workspace"] = "Рабочая область",
            ["Add"] = "Добавить",
            ["Remove"] = "Удалить",
            ["GenerateCode"] = "Сгенерировать код",
            ["SaveToFile"] = "Сохранить в файл",
            ["Block_VariableDecl"] = "Объявление переменной",
            ["Block_Assign"] = "Присваивание",
            ["Block_Arithmetic"] = "Арифметическая операция",
            ["Block_Read"] = "Ввод с консоли",
            ["Block_Print"] = "Вывод на консоль",
            ["Block_If"] = "Условие if",
            ["Block_While"] = "Цикл while",
            ["Block_Comment"] = "Комментарий",
            ["VarDeclTitle"] = "Объявление переменной",
            ["VarDeclTitleEdit"] = "Редактирование переменной",
            ["VarName"] = "Имя переменной:",
            ["VarType"] = "Тип:",
            ["VarInit"] = "Начальное значение (необязательно):",
            ["AssignTitle"] = "Присваивание",
            ["AssignTitleEdit"] = "Редактирование присваивания",
            ["AssignVariable"] = "Переменная:",
            ["AssignExpression"] = "Выражение (C#):",
            ["ArithmeticTitle"] = "Арифметическая операция",
            ["ArithmeticTitleEdit"] = "Редактирование операции",
            ["ArithmeticLeft"] = "Левый операнд (переменная):",
            ["ArithmeticOp"] = "Операция:",
            ["ArithmeticRight"] = "Правый операнд:",
            ["ArithmeticRightVar"] = "Переменная",
            ["ArithmeticRightConst"] = "Константа",
            ["ReadTitle"] = "Ввод с консоли",
            ["ReadTitleEdit"] = "Редактирование ввода",
            ["ReadTarget"] = "Сохранить в переменную:",
            ["PrintTitle"] = "Console.WriteLine",
            ["PrintPrompt"] = "Выражение для вывода:",
            ["IfTitle"] = "if",
            ["IfPrompt"] = "Условие (C# выражение):",
            ["WhileTitle"] = "while",
            ["WhilePrompt"] = "Условие (C# выражение):",
            ["CommentTitle"] = "Комментарий",
            ["CommentPrompt"] = "Текст комментария:",
            ["NoVariables"] = "Сначала объявите хотя бы одну переменную.",
            ["VarNameEmpty"] = "Имя переменной не может быть пустым.",
            ["OK"] = "OK",
            ["Cancel"] = "Отмена",
            ["SaveDialogTitle"] = "Сохранить код",
            ["CodeSaved"] = "Код сохранён. Для компиляции используйте csc или dotnet build.",
            ["GenerateFirst"] = "Сначала сгенерируйте код."
        };

        private static readonly Dictionary<string, string> EnglishStrings = new Dictionary<string, string>
        {
            ["MainFormTitle"] = "C# Block Code Generator",
            ["AvailableBlocks"] = "Available Blocks",
            ["Workspace"] = "Workspace",
            ["Add"] = "Add",
            ["Remove"] = "Remove",
            ["GenerateCode"] = "Generate Code",
            ["SaveToFile"] = "Save to File",
            ["Block_VariableDecl"] = "Variable Declaration",
            ["Block_Assign"] = "Assignment",
            ["Block_Arithmetic"] = "Arithmetic Operation",
            ["Block_Read"] = "Console Input",
            ["Block_Print"] = "Console Output",
            ["Block_If"] = "If Condition",
            ["Block_While"] = "While Loop",
            ["Block_Comment"] = "Comment",
            ["VarDeclTitle"] = "Variable Declaration",
            ["VarDeclTitleEdit"] = "Edit Variable",
            ["VarName"] = "Variable name:",
            ["VarType"] = "Type:",
            ["VarInit"] = "Initial value (optional):",
            ["AssignTitle"] = "Assignment",
            ["AssignTitleEdit"] = "Edit Assignment",
            ["AssignVariable"] = "Variable:",
            ["AssignExpression"] = "Expression (C#):",
            ["ArithmeticTitle"] = "Arithmetic Operation",
            ["ArithmeticTitleEdit"] = "Edit Operation",
            ["ArithmeticLeft"] = "Left operand (variable):",
            ["ArithmeticOp"] = "Operation:",
            ["ArithmeticRight"] = "Right operand:",
            ["ArithmeticRightVar"] = "Variable",
            ["ArithmeticRightConst"] = "Constant",
            ["ReadTitle"] = "Console Input",
            ["ReadTitleEdit"] = "Edit Input",
            ["ReadTarget"] = "Store in variable:",
            ["PrintTitle"] = "Console.WriteLine",
            ["PrintPrompt"] = "Output expression:",
            ["IfTitle"] = "If",
            ["IfPrompt"] = "Condition (C# expression):",
            ["WhileTitle"] = "While",
            ["WhilePrompt"] = "Condition (C# expression):",
            ["CommentTitle"] = "Comment",
            ["CommentPrompt"] = "Comment text:",
            ["NoVariables"] = "Declare at least one variable first.",
            ["VarNameEmpty"] = "Variable name cannot be empty.",
            ["OK"] = "OK",
            ["Cancel"] = "Cancel",
            ["SaveDialogTitle"] = "Save Code",
            ["CodeSaved"] = "Code saved. Use csc or dotnet build to compile.",
            ["GenerateFirst"] = "Generate code first."
        };

        public static string GetString(string key)
        {
            var dict = CurrentLanguage == Language.Russian ? RussianStrings : EnglishStrings;
            return dict.ContainsKey(key) ? dict[key] : $"[{key}]";
        }
    }

    public class LanguageDialog : Form
    {
        public Language SelectedLanguage { get; private set; } = Language.Russian;
        private RadioButton rbRussian;
        private RadioButton rbEnglish;
        private Button btnOk;

        public LanguageDialog()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Select Language / Выберите язык";
            this.Size = new Size(300, 150);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            rbRussian = new RadioButton
            {
                Text = "Русский",
                Location = new Point(30, 20),
                Size = new Size(100, 30),
                Checked = true
            };
            rbEnglish = new RadioButton
            {
                Text = "English",
                Location = new Point(30, 50),
                Size = new Size(100, 30)
            };
            btnOk = new Button
            {
                Text = "OK",
                Location = new Point(180, 70),
                Size = new Size(75, 23),
                DialogResult = DialogResult.OK
            };

            rbRussian.CheckedChanged += (s, e) => { if (rbRussian.Checked) SelectedLanguage = Language.Russian; };
            rbEnglish.CheckedChanged += (s, e) => { if (rbEnglish.Checked) SelectedLanguage = Language.English; };

            this.Controls.AddRange(new Control[] { rbRussian, rbEnglish, btnOk });
            this.AcceptButton = btnOk;
        }
    }

    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var langDialog = new LanguageDialog())
            {
                if (langDialog.ShowDialog() == DialogResult.OK)
                {
                    Localization.CurrentLanguage = langDialog.SelectedLanguage;
                }
            }

            Application.Run(new MainForm());
        }
    }

    public class MainForm : Form
    {
        private ListBox availableBlocksListBox;
        private ListBox workspaceListBox;
        private TextBox generatedCodeTextBox;
        private Button addBlockButton;
        private Button removeBlockButton;
        private Button generateCodeButton;
        private Button saveCodeButton;

        private List<Block> blocks = new List<Block>();

        public MainForm()
        {
            InitializeComponent();
            PopulateAvailableBlocks();
        }

        private void InitializeComponent()
        {
            this.Text = Localization.GetString("MainFormTitle");
            this.Size = new Size(900, 700);

            availableBlocksListBox = new ListBox { Location = new Point(12, 12), Size = new Size(180, 200) };
            workspaceListBox = new ListBox
            {
                Location = new Point(210, 12),
                Size = new Size(180, 200),
                SelectionMode = SelectionMode.One
            };
            generatedCodeTextBox = new TextBox
            {
                Location = new Point(12, 220),
                Size = new Size(860, 400),
                Multiline = true,
                ScrollBars = ScrollBars.Both,
                Font = new Font("Consolas", 10)
            };
            addBlockButton = new Button { Text = Localization.GetString("Add"), Location = new Point(400, 12), Size = new Size(90, 30) };
            removeBlockButton = new Button { Text = Localization.GetString("Remove"), Location = new Point(400, 50), Size = new Size(90, 30) };
            generateCodeButton = new Button { Text = Localization.GetString("GenerateCode"), Location = new Point(400, 90), Size = new Size(140, 30) };
            saveCodeButton = new Button { Text = Localization.GetString("SaveToFile"), Location = new Point(400, 130), Size = new Size(140, 30) };

            addBlockButton.Click += AddBlockButton_Click;
            removeBlockButton.Click += RemoveBlockButton_Click;
            generateCodeButton.Click += GenerateCodeButton_Click;
            saveCodeButton.Click += SaveCodeButton_Click;
            workspaceListBox.DoubleClick += WorkspaceListBox_DoubleClick;

            this.Controls.AddRange(new Control[] {
                availableBlocksListBox,
                workspaceListBox,
                generatedCodeTextBox,
                addBlockButton,
                removeBlockButton,
                generateCodeButton,
                saveCodeButton
            });
        }

        private void PopulateAvailableBlocks()
        {
            availableBlocksListBox.Items.Clear();
            availableBlocksListBox.Items.Add(Localization.GetString("Block_VariableDecl"));
            availableBlocksListBox.Items.Add(Localization.GetString("Block_Assign"));
            availableBlocksListBox.Items.Add(Localization.GetString("Block_Arithmetic"));
            availableBlocksListBox.Items.Add(Localization.GetString("Block_Read"));
            availableBlocksListBox.Items.Add(Localization.GetString("Block_Print"));
            availableBlocksListBox.Items.Add(Localization.GetString("Block_If"));
            availableBlocksListBox.Items.Add(Localization.GetString("Block_While"));
            availableBlocksListBox.Items.Add(Localization.GetString("Block_Comment"));
        }

        private void AddBlockButton_Click(object sender, EventArgs e)
        {
            if (availableBlocksListBox.SelectedItem == null) return;

            string blockType = availableBlocksListBox.SelectedItem.ToString();
            Block block = CreateBlockFromType(blockType);
            if (block != null)
            {
                blocks.Add(block);
                workspaceListBox.Items.Add(block.ToString());
            }
        }

        private void WorkspaceListBox_DoubleClick(object sender, EventArgs e)
        {
            if (workspaceListBox.SelectedItem == null) return;
            int index = workspaceListBox.SelectedIndex;
            Block block = blocks[index];
            Block newBlock = EditBlock(block);
            if (newBlock != null)
            {
                blocks[index] = newBlock;
                workspaceListBox.Items[index] = newBlock.ToString();
            }
        }

        private Block CreateBlockFromType(string type)
        {
            if (type == Localization.GetString("Block_VariableDecl"))
                return ShowVariableDeclarationDialog(null);
            if (type == Localization.GetString("Block_Assign"))
                return ShowAssignDialog(null);
            if (type == Localization.GetString("Block_Arithmetic"))
                return ShowArithmeticDialog(null);
            if (type == Localization.GetString("Block_Read"))
                return ShowReadDialog(null);
            if (type == Localization.GetString("Block_Print"))
            {
                string output = ShowInputDialog(Localization.GetString("PrintPrompt"), Localization.GetString("PrintTitle"), "\"Hello\"");
                if (output == null) return null;
                return new PrintBlock(output);
            }
            if (type == Localization.GetString("Block_If"))
            {
                string condition = ShowInputDialog(Localization.GetString("IfPrompt"), Localization.GetString("IfTitle"), "x > 0");
                if (condition == null) return null;
                return new IfBlock(condition);
            }
            if (type == Localization.GetString("Block_While"))
            {
                string condition = ShowInputDialog(Localization.GetString("WhilePrompt"), Localization.GetString("WhileTitle"), "x < 10");
                if (condition == null) return null;
                return new WhileBlock(condition);
            }
            if (type == Localization.GetString("Block_Comment"))
            {
                string comment = ShowInputDialog(Localization.GetString("CommentPrompt"), Localization.GetString("CommentTitle"), "Это комментарий");
                if (comment == null) return null;
                return new CommentBlock(comment);
            }
            return null;
        }

        private Block EditBlock(Block block)
        {
            if (block is VariableDeclarationBlock)
                return ShowVariableDeclarationDialog(block as VariableDeclarationBlock);
            if (block is AssignBlock)
                return ShowAssignDialog(block as AssignBlock);
            if (block is ArithmeticBlock)
                return ShowArithmeticDialog(block as ArithmeticBlock);
            if (block is ReadBlock)
                return ShowReadDialog(block as ReadBlock);
            if (block is PrintBlock)
            {
                string output = ShowInputDialog(Localization.GetString("PrintPrompt"), Localization.GetString("PrintTitle"), ((PrintBlock)block).OutputExpression);
                if (output == null) return null;
                return new PrintBlock(output);
            }
            if (block is IfBlock)
            {
                string condition = ShowInputDialog(Localization.GetString("IfPrompt"), Localization.GetString("IfTitle"), ((IfBlock)block).Condition);
                if (condition == null) return null;
                return new IfBlock(condition);
            }
            if (block is WhileBlock)
            {
                string condition = ShowInputDialog(Localization.GetString("WhilePrompt"), Localization.GetString("WhileTitle"), ((WhileBlock)block).Condition);
                if (condition == null) return null;
                return new WhileBlock(condition);
            }
            if (block is CommentBlock)
            {
                string comment = ShowInputDialog(Localization.GetString("CommentPrompt"), Localization.GetString("CommentTitle"), ((CommentBlock)block).CommentText);
                if (comment == null) return null;
                return new CommentBlock(comment);
            }
            return null;
        }

        private VariableDeclarationBlock ShowVariableDeclarationDialog(VariableDeclarationBlock existing)
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 250,
                Text = existing == null ? Localization.GetString("VarDeclTitle") : Localization.GetString("VarDeclTitleEdit"),
                StartPosition = FormStartPosition.CenterParent
            };

            Label lblName = new Label() { Left = 10, Top = 10, Text = Localization.GetString("VarName"), AutoSize = true };
            TextBox txtName = new TextBox() { Left = 10, Top = 30, Width = 360, Text = existing?.VariableName ?? "x" };

            Label lblType = new Label() { Left = 10, Top = 60, Text = Localization.GetString("VarType"), AutoSize = true };
            ComboBox cmbType = new ComboBox() { Left = 10, Top = 80, Width = 360, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbType.Items.AddRange(new[] { "int", "string", "bool", "double" });
            if (existing != null && cmbType.Items.Contains(existing.VariableType))
                cmbType.SelectedItem = existing.VariableType;
            else
                cmbType.SelectedIndex = 0;

            Label lblInit = new Label() { Left = 10, Top = 110, Text = Localization.GetString("VarInit"), AutoSize = true };
            TextBox txtInit = new TextBox() { Left = 10, Top = 130, Width = 360, Text = existing?.InitialValue ?? "" };

            Button ok = new Button() { Text = Localization.GetString("OK"), Left = 200, Width = 80, Top = 170, DialogResult = DialogResult.OK };
            Button cancel = new Button() { Text = Localization.GetString("Cancel"), Left = 290, Width = 80, Top = 170, DialogResult = DialogResult.Cancel };

            prompt.Controls.AddRange(new Control[] { lblName, txtName, lblType, cmbType, lblInit, txtInit, ok, cancel });
            prompt.AcceptButton = ok;
            prompt.CancelButton = cancel;

            if (prompt.ShowDialog() == DialogResult.OK)
            {
                string varName = txtName.Text.Trim();
                if (string.IsNullOrWhiteSpace(varName))
                {
                    MessageBox.Show(Localization.GetString("VarNameEmpty"));
                    return null;
                }
                string varType = cmbType.SelectedItem.ToString();
                string initValue = txtInit.Text.Trim();
                return new VariableDeclarationBlock(varName, varType, string.IsNullOrEmpty(initValue) ? null : initValue);
            }
            return null;
        }

        private AssignBlock ShowAssignDialog(AssignBlock existing)
        {
            var variables = blocks.OfType<VariableDeclarationBlock>().Select(v => v.VariableName).ToList();
            if (variables.Count == 0)
            {
                MessageBox.Show(Localization.GetString("NoVariables"));
                return null;
            }

            Form prompt = new Form()
            {
                Width = 400,
                Height = 200,
                Text = existing == null ? Localization.GetString("AssignTitle") : Localization.GetString("AssignTitleEdit"),
                StartPosition = FormStartPosition.CenterParent
            };

            Label lblVar = new Label() { Left = 10, Top = 10, Text = Localization.GetString("AssignVariable"), AutoSize = true };
            ComboBox cmbVar = new ComboBox() { Left = 10, Top = 30, Width = 360, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbVar.Items.AddRange(variables.ToArray());
            if (existing != null && variables.Contains(existing.VariableName))
                cmbVar.SelectedItem = existing.VariableName;
            else
                cmbVar.SelectedIndex = 0;

            Label lblValue = new Label() { Left = 10, Top = 60, Text = Localization.GetString("AssignExpression"), AutoSize = true };
            TextBox txtValue = new TextBox() { Left = 10, Top = 80, Width = 360, Text = existing?.ValueExpression ?? "0" };

            Button ok = new Button() { Text = Localization.GetString("OK"), Left = 200, Width = 80, Top = 120, DialogResult = DialogResult.OK };
            Button cancel = new Button() { Text = Localization.GetString("Cancel"), Left = 290, Width = 80, Top = 120, DialogResult = DialogResult.Cancel };

            prompt.Controls.AddRange(new Control[] { lblVar, cmbVar, lblValue, txtValue, ok, cancel });
            prompt.AcceptButton = ok;
            prompt.CancelButton = cancel;

            if (prompt.ShowDialog() == DialogResult.OK)
            {
                return new AssignBlock(cmbVar.SelectedItem.ToString(), txtValue.Text);
            }
            return null;
        }

        private ArithmeticBlock ShowArithmeticDialog(ArithmeticBlock existing)
        {
            var variables = blocks.OfType<VariableDeclarationBlock>().Select(v => v.VariableName).ToList();
            if (variables.Count == 0)
            {
                MessageBox.Show(Localization.GetString("NoVariables"));
                return null;
            }

            Form prompt = new Form()
            {
                Width = 500,
                Height = 250,
                Text = existing == null ? Localization.GetString("ArithmeticTitle") : Localization.GetString("ArithmeticTitleEdit"),
                StartPosition = FormStartPosition.CenterParent
            };

            Label lblLeft = new Label() { Left = 10, Top = 10, Text = Localization.GetString("ArithmeticLeft"), AutoSize = true };
            ComboBox cmbLeft = new ComboBox() { Left = 10, Top = 30, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbLeft.Items.AddRange(variables.ToArray());
            if (existing != null && variables.Contains(existing.LeftVariable))
                cmbLeft.SelectedItem = existing.LeftVariable;
            else
                cmbLeft.SelectedIndex = 0;

            Label lblOp = new Label() { Left = 220, Top = 10, Text = Localization.GetString("ArithmeticOp"), AutoSize = true };
            ComboBox cmbOp = new ComboBox() { Left = 220, Top = 30, Width = 60, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbOp.Items.AddRange(new[] { "+", "-", "*", "/" });
            if (existing != null)
                cmbOp.SelectedItem = existing.Operation;
            else
                cmbOp.SelectedIndex = 0;

            Label lblRightType = new Label() { Left = 290, Top = 10, Text = Localization.GetString("ArithmeticRight"), AutoSize = true };
            ComboBox cmbRightType = new ComboBox() { Left = 290, Top = 30, Width = 90, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbRightType.Items.AddRange(new[] { Localization.GetString("ArithmeticRightVar"), Localization.GetString("ArithmeticRightConst") });
            cmbRightType.SelectedIndex = 0;

            Label lblRightVar = new Label() { Left = 10, Top = 70, Text = Localization.GetString("ArithmeticRightVar"), AutoSize = true };
            ComboBox cmbRightVar = new ComboBox() { Left = 10, Top = 90, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbRightVar.Items.AddRange(variables.ToArray());
            cmbRightVar.SelectedIndex = 0;

            Label lblRightConst = new Label() { Left = 220, Top = 70, Text = Localization.GetString("ArithmeticRightConst"), AutoSize = true };
            TextBox txtRightConst = new TextBox() { Left = 220, Top = 90, Width = 150, Text = "0" };

            // Локальная функция для обновления видимости
            void UpdateRightVisibility()
            {
                bool isVar = cmbRightType.SelectedItem.ToString() == Localization.GetString("ArithmeticRightVar");
                lblRightVar.Visible = cmbRightVar.Visible = isVar;
                lblRightConst.Visible = txtRightConst.Visible = !isVar;
            }

            cmbRightType.SelectedIndexChanged += (s, e) => UpdateRightVisibility();

            // Если редактируем существующий блок, восстанавливаем правый операнд
            if (existing != null)
            {
                if (existing.RightIsVariable)
                {
                    cmbRightType.SelectedItem = Localization.GetString("ArithmeticRightVar");
                    if (variables.Contains(existing.RightVariable))
                        cmbRightVar.SelectedItem = existing.RightVariable;
                }
                else
                {
                    cmbRightType.SelectedItem = Localization.GetString("ArithmeticRightConst");
                    txtRightConst.Text = existing.RightConstant;
                }
            }

            // Установить начальную видимость
            UpdateRightVisibility();

            Button ok = new Button() { Text = Localization.GetString("OK"), Left = 300, Width = 80, Top = 170, DialogResult = DialogResult.OK };
            Button cancel = new Button() { Text = Localization.GetString("Cancel"), Left = 390, Width = 80, Top = 170, DialogResult = DialogResult.Cancel };

            prompt.Controls.AddRange(new Control[] {
                lblLeft, cmbLeft, lblOp, cmbOp,
                lblRightType, cmbRightType,
                lblRightVar, cmbRightVar,
                lblRightConst, txtRightConst,
                ok, cancel
            });

            prompt.AcceptButton = ok;
            prompt.CancelButton = cancel;

            if (prompt.ShowDialog() == DialogResult.OK)
            {
                string leftVar = cmbLeft.SelectedItem.ToString();
                string op = cmbOp.SelectedItem.ToString();
                bool rightIsVar = cmbRightType.SelectedItem.ToString() == Localization.GetString("ArithmeticRightVar");
                string rightVar = rightIsVar ? cmbRightVar.SelectedItem.ToString() : null;
                string rightConst = rightIsVar ? null : txtRightConst.Text;
                return new ArithmeticBlock(leftVar, op, rightIsVar, rightVar, rightConst);
            }
            return null;
        }

        private ReadBlock ShowReadDialog(ReadBlock existing)
        {
            var variables = blocks.OfType<VariableDeclarationBlock>().Select(v => v.VariableName).ToList();
            if (variables.Count == 0)
            {
                MessageBox.Show(Localization.GetString("NoVariables"));
                return null;
            }

            Form prompt = new Form()
            {
                Width = 400,
                Height = 150,
                Text = existing == null ? Localization.GetString("ReadTitle") : Localization.GetString("ReadTitleEdit"),
                StartPosition = FormStartPosition.CenterParent
            };

            Label lblVar = new Label() { Left = 10, Top = 10, Text = Localization.GetString("ReadTarget"), AutoSize = true };
            ComboBox cmbVar = new ComboBox() { Left = 10, Top = 30, Width = 360, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbVar.Items.AddRange(variables.ToArray());
            if (existing != null && variables.Contains(existing.TargetVariable))
                cmbVar.SelectedItem = existing.TargetVariable;
            else
                cmbVar.SelectedIndex = 0;

            Button ok = new Button() { Text = Localization.GetString("OK"), Left = 200, Width = 80, Top = 70, DialogResult = DialogResult.OK };
            Button cancel = new Button() { Text = Localization.GetString("Cancel"), Left = 290, Width = 80, Top = 70, DialogResult = DialogResult.Cancel };

            prompt.Controls.AddRange(new Control[] { lblVar, cmbVar, ok, cancel });
            prompt.AcceptButton = ok;
            prompt.CancelButton = cancel;

            if (prompt.ShowDialog() == DialogResult.OK)
            {
                return new ReadBlock(cmbVar.SelectedItem.ToString());
            }
            return null;
        }

        private string ShowInputDialog(string prompt, string title, string defaultValue = "")
        {
            Form promptForm = new Form()
            {
                Width = 400,
                Height = 150,
                Text = title,
                StartPosition = FormStartPosition.CenterParent
            };
            Label label = new Label() { Left = 10, Top = 10, Text = prompt, AutoSize = true };
            TextBox textBox = new TextBox() { Left = 10, Top = 40, Width = 360, Text = defaultValue };
            Button confirmation = new Button() { Text = Localization.GetString("OK"), Left = 200, Width = 80, Top = 70, DialogResult = DialogResult.OK };
            Button cancel = new Button() { Text = Localization.GetString("Cancel"), Left = 290, Width = 80, Top = 70, DialogResult = DialogResult.Cancel };
            promptForm.Controls.AddRange(new Control[] { label, textBox, confirmation, cancel });
            promptForm.AcceptButton = confirmation;
            promptForm.CancelButton = cancel;

            return promptForm.ShowDialog() == DialogResult.OK ? textBox.Text : null;
        }

        private void RemoveBlockButton_Click(object sender, EventArgs e)
        {
            if (workspaceListBox.SelectedIndex >= 0)
            {
                int index = workspaceListBox.SelectedIndex;
                blocks.RemoveAt(index);
                workspaceListBox.Items.RemoveAt(index);
            }
        }

        private void GenerateCodeButton_Click(object sender, EventArgs e)
        {
            string code = GenerateCodeFromBlocks();
            generatedCodeTextBox.Text = code;
        }

        private string GenerateCodeFromBlocks()
        {
            var code = new StringBuilder();
            code.AppendLine("using System;");
            code.AppendLine();
            code.AppendLine("namespace GeneratedProgram");
            code.AppendLine("{");
            code.AppendLine("    class Program");
            code.AppendLine("    {");
            code.AppendLine("        static void Main()");
            code.AppendLine("        {");

            foreach (var block in blocks)
            {
                string blockCode = block.GenerateCode();
                foreach (var line in blockCode.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
                {
                    code.AppendLine("            " + line);
                }
            }

            code.AppendLine("        }");
            code.AppendLine("    }");
            code.AppendLine("}");
            return code.ToString();
        }

        private void SaveCodeButton_Click(object sender, EventArgs e)
        {
            string code = generatedCodeTextBox.Text;
            if (string.IsNullOrWhiteSpace(code))
            {
                MessageBox.Show(Localization.GetString("GenerateFirst"));
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Title = Localization.GetString("SaveDialogTitle"),
                Filter = "C# files|*.cs",
                FileName = "Program.cs"
            };
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(saveDialog.FileName, code);
                MessageBox.Show(Localization.GetString("CodeSaved"));
            }
        }
    }

    public abstract class Block
    {
        public abstract string GenerateCode();
    }

    public class VariableDeclarationBlock : Block
    {
        public string VariableName { get; set; }
        public string VariableType { get; set; }
        public string InitialValue { get; set; }

        public VariableDeclarationBlock(string varName, string varType, string initValue = null)
        {
            VariableName = varName;
            VariableType = varType;
            InitialValue = initValue;
        }

        public override string GenerateCode()
        {
            if (string.IsNullOrEmpty(InitialValue))
                return $"{VariableType} {VariableName};";
            else
                return $"{VariableType} {VariableName} = {InitialValue};";
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(InitialValue))
                return $"Объявление: {VariableType} {VariableName}";
            else
                return $"Объявление: {VariableType} {VariableName} = {InitialValue}";
        }
    }

    public class AssignBlock : Block
    {
        public string VariableName { get; set; }
        public string ValueExpression { get; set; }

        public AssignBlock(string varName, string value)
        {
            VariableName = varName;
            ValueExpression = value;
        }

        public override string GenerateCode() => $"{VariableName} = {ValueExpression};";
        public override string ToString() => $"Присваивание: {VariableName} = {ValueExpression}";
    }

    public class ArithmeticBlock : Block
    {
        public string LeftVariable { get; set; }
        public string Operation { get; set; }
        public bool RightIsVariable { get; set; }
        public string RightVariable { get; set; }
        public string RightConstant { get; set; }

        public ArithmeticBlock(string leftVar, string op, bool rightIsVar, string rightVar, string rightConst)
        {
            LeftVariable = leftVar;
            Operation = op;
            RightIsVariable = rightIsVar;
            RightVariable = rightVar;
            RightConstant = rightConst;
        }

        public override string GenerateCode()
        {
            string right = RightIsVariable ? RightVariable : RightConstant;
            return $"{LeftVariable} = {LeftVariable} {Operation} {right};";
        }

        public override string ToString()
        {
            string right = RightIsVariable ? RightVariable : RightConstant;
            return $"{LeftVariable} = {LeftVariable} {Operation} {right}";
        }
    }

    public class ReadBlock : Block
    {
        public string TargetVariable { get; set; }

        public ReadBlock(string targetVar)
        {
            TargetVariable = targetVar;
        }

        public override string GenerateCode()
        {
            return $"{TargetVariable} = Console.ReadLine();";
        }

        public override string ToString() => $"Ввод: {TargetVariable} = Console.ReadLine()";
    }

    public class PrintBlock : Block
    {
        public string OutputExpression { get; set; }

        public PrintBlock(string output) => OutputExpression = output;

        public override string GenerateCode() => $"Console.WriteLine({OutputExpression});";
        public override string ToString() => $"Вывод: {OutputExpression}";
    }

    public class IfBlock : Block
    {
        public string Condition { get; set; }

        public IfBlock(string condition) => Condition = condition;

        public override string GenerateCode() =>
            $"if ({Condition})\n            {{\n                // Добавьте код внутри if\n            }}";
        public override string ToString() => $"if ({Condition})";
    }

    public class WhileBlock : Block
    {
        public string Condition { get; set; }

        public WhileBlock(string condition) => Condition = condition;

        public override string GenerateCode() =>
            $"while ({Condition})\n            {{\n                // Добавьте код внутри цикла\n            }}";
        public override string ToString() => $"while ({Condition})";
    }

    public class CommentBlock : Block
    {
        public string CommentText { get; set; }

        public CommentBlock(string comment) => CommentText = comment;

        public override string GenerateCode() => $"// {CommentText}";
        public override string ToString() => $"// {CommentText}";
    }
}