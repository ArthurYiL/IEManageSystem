const createModulesFile = require('./createModulesFile').createModulesFile;
createModulesFile(
    "./src/RNApp",
    ["RNStart"],
    "Module.js",
    "",
    "./src/RNApp/ModuleList.js"
);

// 该文件为 RN 的配置文件，我无法将该文件移动 src/RNApp/RNStart 下
module.exports = {
    project: {
        android: {
            sourceDir: "src/RNApp/RNStart/android"
        }
    }
}