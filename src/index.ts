import readline from "readline";

const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout,
});

console.log("Mythlog initialized...");

rl.question("What is your name?", (answer: string) => {
  console.log(`Hello ${answer}`);
  rl.close;
});
