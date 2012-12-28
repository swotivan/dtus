var SESSION_USER;

function HAS_PERMISSION(role, alert) {
    if (alert == undefined)
        alert = true;

    if (!SESSION_USER) {
        if (alert) {
            Ext.Msg.alert('System', "No Permission");
        }
        return false;
    } else {
        try {
            var roles = SESSION_USER.post.role;
            for (var i = 0; i < roles.length; i++) {
                if (roles[i].name == role || roles[i].name == 'xx' || roles[i].name == 'xx' ||
                                        roles[i].name == 'xx')
                    return true;
            }
            if (alert) {
                Ext.Msg.alert('System', "No Permission");
            }
            return false;
        } catch (e) {
            return false;
        }
    }
}

function GOTO_ORDER_MODULE() {
    hasPermission = HAS_PERMISSION("xx");
    if (hasPermission) {
        location.href = "order.aspx";
    }
}

function GOTO_JOB_MODULE() {
    hasPermission = true;
    if (hasPermission) {
        location.href = "job.aspx";
    }
}

function GOTO_ADMIN_MODULE() {
    hasPermission = HAS_PERMISSION("xx");
    if (hasPermission) {
        location.href = "admin.aspx";
    }
}

function GOTO_INVENTORY_MODULE() {
    hasPermission = HAS_PERMISSION("xx", false) || HAS_PERMISSION("xx", false);
    if (hasPermission) {
        location.href = "inventory.aspx";
    }
    else {
        Ext.Msg.alert('System', "No Permission");
    }
}

function GOTO_DOCUMENT_MODULE() {
    hasPermission = true;
    if (hasPermission) {
        location.href = "document.aspx";
    }
}

function GOTO_PRODUCTION_MODULE() {
    hasPermission = HAS_PERMISSION("xx");
    if (hasPermission) {
        location.href = "production.aspx";
    }
}

function GOTO_PRODUCTIONLOG_MODULE() {
    hasPermission = true;
    if (hasPermission) {
        location.href = "productionlog.aspx";
    }
}

function LOGOUT() {
    //location.href = "UserACController?action=logout";
}

function GetJsonData(sUrl, xParameter, callback) {
    Ext.Ajax.request({
        url: sUrl,
        params: xParameter,
        success: function(response) {
            var jsonResp = Ext.JSON.decode(response.responseText);
            callback(jsonResp);
        },
        failure: function(response) {
            var jsonResp = Ext.JSON.decode(response.responseText);
            callback(jsonResp);
        }
    });
}

Ext.define('master.controller.c_master', {
    extend: 'Ext.app.Controller',

    views: ['v_master'],

    init: function() {
        
        //Role Data
    /*
    Ext.define('RoleData', {
    extend: 'Ext.data.Model',
    fields: ['id', 'name', 'remark']
    });

        //All role store

        Ext.create('Ext.data.Store', {
    storeId: 'allMoldStore',
    model: 'MoldData',
    proxy: {
    type: 'ajax',
    url: 'MoldController?action=getAllMold',
    reader: {
    type: 'json',
    root: 'data',
    model: 'MoldData'
    }
    }
    });
    */
    }
});
