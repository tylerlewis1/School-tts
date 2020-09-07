'use strict';
const express = require('express');
const fs = require('fs');
const router = express.Router();
var data = null;
router.post('/:data', (req, res, next) =>{
    data = req.params.data;
    log(data);
    res.status('200').json({
        status: 'Sent'
    });
});
    router.get('/', (req,res,next) =>{
        res.send(data);
        
    });
   
    function log(data){
        const date = new Date();
        var innerlog = data.split('|');
        let path = ('./Logs/Month ' + (date.getMonth()+1)+ '.txt');
        fs.exists(path, (exists)=>{    
            if(exists){
                var olddata = fs.readFileSync(path);
                fs.writeFileSync(path, date + ': ' + innerlog[0] + ': '+ innerlog[1] + '\n' +  olddata);
            }else{
                fs.writeFileSync(path, date + ': ' + innerlog[0] + ': '+ innerlog[1]);
            }
    });
}   
    module.exports = router;
