/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
"use strict";function pipeLoggingToParent(){function e(e){const n=[],o=[];let r;if(e.length)for(let n=0;n<e.length;n++){if(void 0===e[n])e[n]="undefined";else if(e[n]instanceof Error){const t=e[n];t.stack?e[n]=t.stack:e[n]=t.toString()}o.push(e[n])}if("true"===process.env.VSCODE_LOG_STACK){const e=(new Error).stack;o.push({__$stack:e.split("\n").slice(3).join("\n")})}try{r=JSON.stringify(o,function(e,t){if(function(e){return!("object"!=typeof e||null===e||Array.isArray(e)||e instanceof RegExp||e instanceof Date)}(t)||Array.isArray(t)){if(-1!==n.indexOf(t))return"[Circular]";n.push(t)}return t})}catch(e){return"Output omitted for an object that cannot be inspected ("+e.toString()+")"}return r&&r.length>t?"Output omitted for a large object that exceeds the limits":r}function n(e){try{process.send(e)}catch(e){}}const t=1e5;"true"===process.env.VERBOSE_LOGGING?(console.log=function(){n({type:"__$console",severity:"log",arguments:e(arguments)})},console.info=function(){n({type:"__$console",severity:"log",
arguments:e(arguments)})},console.warn=function(){n({type:"__$console",severity:"warn",arguments:e(arguments)})}):(console.log=function(){},console.warn=function(){},console.info=function(){}),console.error=function(){n({type:"__$console",severity:"error",arguments:e(arguments)})}}function disableSTDIO(){const e=new(require("stream").Writable)({write:function(){}});process.__defineGetter__("stdout",function(){return e}),process.__defineGetter__("stderr",function(){return e}),process.__defineGetter__("stdin",function(){return e})}function handleExceptions(){process.on("uncaughtException",function(e){console.error("Uncaught Exception: ",e)}),process.on("unhandledRejection",function(e){console.error("Unhandled Promise Rejection: ",e)})}function terminateWhenParentTerminates(){const e=Number(process.env.VSCODE_PARENT_PID);"number"!=typeof e||isNaN(e)||setInterval(function(){try{process.kill(e,0)}catch(e){process.exit()}},5e3)}function configureCrashReporter(){const e=process.env.CRASH_REPORTER_START_OPTIONS
;if("string"==typeof e)try{const n=JSON.parse(e);n&&process.crashReporter.start(n)}catch(e){console.error(e)}}const bootstrap=require("./bootstrap");bootstrap.enableASARSupport(),process.send&&"true"===process.env.PIPE_LOGGING&&pipeLoggingToParent(),process.env.VSCODE_ALLOW_IO||disableSTDIO(),process.env.VSCODE_HANDLES_UNCAUGHT_ERRORS||handleExceptions(),process.env.VSCODE_PARENT_PID&&terminateWhenParentTerminates(),configureCrashReporter(),require("./bootstrap-amd").load(process.env.AMD_ENTRYPOINT);
//# sourceMappingURL=https://ticino.blob.core.windows.net/sourcemaps/7c66f58312b48ed8ca4e387ebd9ffe9605332caa/core/bootstrap-fork.js.map
