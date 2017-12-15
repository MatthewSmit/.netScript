# .netScript
An ECMAScript interpreter in .net.

## Features
- Basic and incomplete support for ECMAScript.

## Future Features
- Compile to custom bytecode rather then iterating over the node tree.
- JIT into .net.
- AOT into .net.
- Complete ECMAScript 2018 Specification.
- Complete support for Stage 3 ECMAScript proposals.
- Complete support for Stage 2 ECMAScript proposals.
- Complete support for Stage 1 ECMAScript proposals.

## Usage

    // Create an agent (an ECMAScript host)
    var agent = new Agent();
    // Create a global function named print taking one argument
    agent.Global["print"] = agent.CreateUserFunction(arguments => {
	    Console.WriteLine(arguments[0].ToString());
	    return ScriptValue.Undefined;
	});
    // Queue a script job
    agent.QueueCode("print('Hello World');");
    // Run all the jobs
    agent.RunAllJobs();
