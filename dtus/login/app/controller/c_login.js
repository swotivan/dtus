Ext.define('login.controller.c_login', {
    extend: 'Ext.app.Controller',

    views: [
            'v_login'
        ],

    init: function() {
        this.control({
            'viewport > panel': {
                render: this.onPanelRendered
            },
            'button[text="Login"]': {
                click: this.onLoginBtnClick
            },
            'button[text="Cancel"]': {
                click: this.onCancelBtnClick
            },
            'textfield[name="login_id"]': {
                specialkey: this.onTxtLoginSpecialKey
            },
            'textfield[name="password"]': {
                specialkey: this.onTxtLoginSpecialKey
            }
        });
    },

    onPanelRendered: function() {

    },

    onLoginBtnClick: function(btn) {
        btn.up('viewport').down('form[id="loginForm"]').getForm().submit({
            url: 'login/login.aspx?action=login',
            success: function(form, resp) {
                try {
                    result = Ext.JSON.decode(resp.response.responseText).data;
                    alert(result)
                } catch (e) {
                    Ext.Msg.alert('Login', 'Login failed');
                }
            },
            failure: function(form, resp) {
                Ext.Msg.alert('Login', resp.result.msg);
            }
        });
    },

    onTxtLoginSpecialKey: function(field, e) {
        if (e.getKey() == e.ENTER) {
            this.onLoginBtnClick(field);
        }
    },

    onCancelBtnClick: function(btn) {
        btn.up('viewport').down('form[id="loginForm"]').getForm().reset();
    }
});