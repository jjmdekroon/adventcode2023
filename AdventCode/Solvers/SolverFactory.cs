using AdventCode.Solvers.Q3;
using AdventCode.Solvers.Q4;
using AdventCode.Solvers.Q5;
using AdventCode.Solvers.Q6;
using AdventCode.Solvers.Q7;
using AdventCode.Solvers.Q8;
using AdventCode.Solvers.Q9;

namespace AdventCode.Solvers;

public static  class SolverFactory
{
    public static ISolver? CreateSolver(Question question)
    {
        return question switch
        {
            Question.Question_1_A => new SolverQuestion1A(),
            Question.Question_1_B => new SolverQuestion1B(),
            
            Question.Question_2_A => new SolverQuestion2A(),
            Question.Question_2_B => new SolverQuestion2B(),
            
            Question.Question_3_A => new SolverQuestion3A(),
            Question.Question_3_B => new SolverQuestion3B(),

            Question.Question_4_A => new SolverQuestion4A(),
            Question.Question_4_B => new SolverQuestion4B(),

            Question.Question_5_A => new SolverQuestion5A(),
            Question.Question_5_B => new SolverQuestion5B(),

            Question.Question_6_A => new SolverQuestion6A(),
            Question.Question_6_B => new SolverQuestion6B(),

            Question.Question_7_A => new SolverQuestion7A(),

            Question.Question_8_A => new SolverQuestion8A(),
            Question.Question_8_B => new SolverQuestion8B(),

            Question.Question_9_A => new SolverQuestion9A(),

            _ => null
        };
    }
}
