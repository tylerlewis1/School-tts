var ld = null;
var code = null;

console.log("running");
chrome.runtime.onMessage.addListener(codeSet);
function codeSet(code1, sender, sendResponce){
    code = code1;
    if(code != null){
        console.log("started");
        get();
        setInterval(function(){get()}, 2500);
    }
}


async function get(){
    var oReq = new XMLHttpRequest();
    oReq.addEventListener("load", reqListener);
    oReq.open("GET", "WEBSERVER");
    oReq.send();
}
function reqListener () {
    var data = this.responseText();
    if(data != ld){
        ld = data;
        var parse = data.split('|')
        if(parse[2] != code){
            return;
        }
        console.log(this.responseText);
        var msg = new SpeechSynthesisUtterance(parse[0] + " said " + parse[1]);
        window.speechSynthesis.speak(msg);
    }
  }
