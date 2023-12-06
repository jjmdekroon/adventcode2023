﻿using AdventCode.Solvers.Q3;
using AdventCode.Solvers.Q4;
using AdventCode.Solvers.Q5;
using AdventCode.Solvers.Q6;

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

            Question.Question_6_A => new SolverQuestion6A(),
            Question.Question_6_B => new SolverQuestion6B(),
            _ => null
        };
    }
}
