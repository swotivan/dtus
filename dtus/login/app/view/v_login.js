Ext.define('login.view.v_login', {
    extend: 'Ext.form.Panel',

    alias: 'widget.loginform',

    title: 'System Login',

    id: 'loginForm',


    initComponent: function() {

        this.layout = 'table';

        this.items = [{
            colspan: 3,
            border: false,
            height: '200'
        }, {
            border: false,
            width: '200'
        }, {
            border: false,
            items: [{
                xtype: 'textfield',
                name: 'login_id',
                fieldLabel: 'User ID',
                labelWidth: 50
            }, {
                xtype: 'textfield',
                name: 'password',
                fieldLabel: 'Password',
                inputType: 'password',
                labelWidth: 50
            }, {
                xtype: 'button',
                text: 'Login',
                id: 'btnLogin'
            }, {
                xtype: 'button',
                text: 'Cancel'
}]
            }, {
                border: false
            }, {
                colspan: 3,
                border: false,
                height: 400
}];



                this.callParent(arguments);
            }
        });