import readline from "readline";
import { CommandRouter } from "./command";
import { TickService } from "./game";
import { StateStore } from "./state";
import { Dice } from "./core/dice";

const router = new CommandRouter();
const dice = new Dice();

const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout,
});

const store = new StateStore({
  tick: 0,
  playerName: "Hero",
});

const tick = new TickService();

tick.onTick(() => {
  console.log(`Tick: ${store.state.tick}`);
});

console.log("Game started. Type !help for help.");

rl.on("line", (input: string) => {
  const result = router.route(input, { dice, store, tick });

  if (result) {
    console.log(result.output);

    store.set(state => ({
      ...state,
      tick: state.tick + 1,
    }));

    tick.tick();
  }
});
