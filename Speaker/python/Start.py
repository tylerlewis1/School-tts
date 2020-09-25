import requests
import urllib3
import time
import pyttsx3
print('starting')
engine = pyttsx3.init()
urllib3.disable_warnings()
data = "starting"
print('running')
while(True):
    time.sleep(.5)
    try:
        get = requests.get('API REQUEST URL', verify=False)
        if(get.text != data):
            data = (get.text)
            innerdata = get.text.split("|")
            engine.setProperty('rate', 120)
            engine.say(innerdata[0] + "Said " + innerdata[1])
            engine.runAndWait()
    except:
        print('error')
