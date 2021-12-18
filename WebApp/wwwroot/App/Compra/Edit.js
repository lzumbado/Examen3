"use strict";
var CompraEdit;
(function (CompraEdit) {
    var Entity = $("#AppEdit").data("entity");
    var Formulario = new Vue({
        data: {
            Formulario: "#FormEdit",
            Entity: Entity
        },
        methods: {
            ClienteServicio: function (entity) {
                console.log(entity);
                if (entity.IdCompra == null) {
                    return App.AxiosProvider.CompraGuardar(entity);
                }
                else {
                    return App.AxiosProvider.CompraActualizar(entity);
                }
            },
            Save: function () {
                if (BValidateData(this.Formulario)) {
                    Loading.fire("Guardando");
                    this.ClienteServicio(this.Entity).then(function (data) {
                        Loading.close();
                        if (data.CodeError == 0) {
                            Toast.fire({ title: "Se guardo correctamente", icon: "success" })
                                .then(function () { return window.location.href = "Compra/Grid"; });
                        }
                        else {
                            Toast.fire({ title: data.MsgError, icon: "error" });
                        }
                    }).catch(function (c) { return console.log(c); });
                }
                else {
                    Toast.fire({ title: "Por favor complete los campos requeridos" });
                }
            }
        },
        mounted: function () {
            CreateValidator(this.Formulario);
        },
        created: function () {
            var _a;
            this.Entity.FechaCompra = (_a = this.Entity.FechaCompra) === null || _a === void 0 ? void 0 : _a.slice(0, 10);
        }
    });
    Formulario.$mount("#AppEdit");
})(CompraEdit || (CompraEdit = {}));
//# sourceMappingURL=Edit.js.map