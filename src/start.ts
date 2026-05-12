import readline from 'readline';
import { CommandRouter } from './command';

const router = new CommandRouter();

const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout,
});

console.log('Game started. Type !help');

rl.on('line', (input: string) => {
  const result = router.route(input);

  if (result) {
    console.log(result.output);
  }
});
