using AdventCode.Solvers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdventCode
{
    public partial class Form1 : Form
    {
        private ISolver? _solver;

        public Form1()
        {
            InitializeComponent();

            foreach (var item in Enum.GetValues(typeof(Question)))
            {
                cbSelection.Items.Add((Question)item);
            }
        }

        private void cbSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = cbSelection.SelectedItem;
            if (selectedItem is null)
            {
                answer.Text = "No question selected";
                return;
            }

            var question = (Question)selectedItem;
            _solver = CreateSolverForQuestion(question);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var input = InputForAnswer.Text;
            if (String.IsNullOrEmpty(input))
            {
                answer.Text = "No input";
                return;
            }

            _solver?.SetInput(input);
            answer.Text = _solver?.SolveQuestion() ?? "Not possible to solve";
        }

        private ISolver? CreateSolverForQuestion(Question question)
        {
            return question switch
            {
                Question.Question_1_A => new SolverQuestion1A(),
                Question.Question_1_B => new SolverQuestion1B(),
                Question.Question_2_A => new SolverQuestion2A(),
                Question.Question_2_B => new SolverQuestion2B(),
                _ => null
            };
        }
    }
}
