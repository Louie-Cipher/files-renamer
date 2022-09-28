const fs = require('fs');
const glob = require('glob');
require('dotenv').config();

const { oldRM, newRM } = process.env;

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

// read files in the newly renamed directory
const files = glob.sync(`./${newRM}/**/*`, { nodir: true });

// replace every occurrence of the old name with the new name inside files content
for (const file of files) {
    let data = fs.readFileSync(file, 'utf8');
    let result = data.replace(new RegExp(oldRM, 'g'), newRM);
    fs.writeFileSync(file, result, 'utf8');
}

console.log(`${dirCount} directories renamed`);
console.log(`${fileCount} files renamed and content replaced`);