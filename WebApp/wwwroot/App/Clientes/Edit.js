"use strict";
var ClientesEdit;
(function (ClientesEdit) {
    var Entity = $("#AppEdit").data("entity");
    var Formulario = new Vue({
        data: {
            Formulario: "#FormEdit",
            Entity: Entity
        },
        methods: {
            ClienteServicio: function (entity) {
                console.log(entity);
                if (entity.ClientesId == null) {
                    return App.AxiosProvider.ClientesGuardar(entity);
                }
                else {
                    return App.AxiosProvider.ClientesActualizar(entity);
                }
            },
            Save: function () {
                if (BValidateData(this.Formulario)) {
                    Loading.fire("Guardando");
                    this.ClienteServicio(this.Entity).then(function (data) {
                        Loading.close();
                        if (data.CodeError == 0) {
                            Toast.fire({ title: "Se guardo correctamente", icon: "success" })
                                .then(function () { return window.location.href = "Clientes/Grid"; });
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
        //created() {
        //    this.Entity.FechaNacimiento = this.Entity.FechaNacimiento?.slice(0, 10);
        //}
    });
    Formulario.$mount("#AppEdit");
})(ClientesEdit || (ClientesEdit = {}));
//# sourceMappingURL=Edit.js.map