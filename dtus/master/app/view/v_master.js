Ext.define('master.view.v_master', {
    extend: 'Ext.form.Panel',

    alias: 'widget.master',

    initComponent: function() {
        this.layout = 'table';

        this.items = [{
            colspan: 3,
            border: false
        }, {
            border: false
        }, {
            border: false,
            items: [{
                xtype: 'box',
                html: '<table><tr><td><img src="resources/images/g-dico.png" width=160 height=50/></td>' +
                                '<td align="center" width="120"><a href="#" onclick="GOTO_ORDER_MODULE();" id="link_order">A</a></td>' +
                                '<td align="center" width="120"><a href="#" onclick="GOTO_PRODUCTION_MODULE();" id="link_job">B</a></td>' +
                                '<td align="center" width="120"><a href="#" onclick="GOTO_JOB_MODULE();" id="link_job">C</a></td>' +
                                '<td align="center" width="120"><a href="#" onclick="GOTO_INVENTORY_MODULE();" id="link_job">D</a></td>' +
                                '<td align="center" width="120"><a href="#" onclick="GOTO_PRODUCTIONLOG_MODULE();" id="link_job">E</a></td>' +
                                '<td align="center" width="120"><a href="#" onclick="GOTO_ADMIN_MODULE();" id="link_admin">F</a></td>' +
                                '<td align="center" width="120"><a href="#" onclick="LOGOUT();" id="link_logout">G</a></td>' +
                                '<td align="right" width="60"></td>' +
                                '<td align="left" width="100"><span id="link_user"/></td>' +
                                '</tr></table>'
}]
            }, {
                border: false
            }, {
                colspan: 3,
                border: false
}];
                this.callParent(arguments);
            }
        });