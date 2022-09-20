const fs = require('fs');

const oldRM = '29000';
const newRM = '37740';

fs.renameSync(`./${oldRM}`, `./${newRM}`);

const mainDir = fs.readdirSync(`./${newRM}`);

let dirCount = 0;
let fileCount = 0;

for (const dir of mainDir) {

    const newDirName = dir.replace(oldRM, newRM);
    dirCount++;

    fs.renameSync(`./${newRM}/${dir}`, `./${newRM}/${newDirName}`);

    const files = fs.readdirSync(`./${newRM}/${newDirName}`);

    for (const file of files) {

        if (['.vs', 'bin', 'obj'].includes(file)) fs.rmSync(`./${newRM}/${newDirName}/${file}`, { recursive: true });
        else {
            fs.renameSync(`./${newRM}/${newDirName}/${file}`, `./${newRM}/${newDirName}/${file.replace(oldRM, newRM)}`);
            fileCount++;
        }
    }
}

console.log(`${dirCount} directories renamed`);
console.log(`${fileCount} files renamed`);