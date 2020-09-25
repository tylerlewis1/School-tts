var code1 = "";
document.addEventListener('DOMContentLoaded', function () {
    document.querySelector('button').addEventListener('click', onclick, false)
    function onclick(){
        code1 = document.getElementById('classcode').value
            alert("Class code set");
            chrome.runtime.sendMessage(code1);
       
    }
});
