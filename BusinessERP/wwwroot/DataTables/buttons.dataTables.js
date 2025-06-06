/*!
 Buttons for DataTables 1.5.4
 ©2016-2018 SpryMedia Ltd - datatables.net/license
*/
var $jscomp = $jscomp || {}; $jscomp.scope = {}; $jscomp.findInternal = function (d, p, m) { d instanceof String && (d = String(d)); for (var l = d.length, g = 0; g < l; g++) { var u = d[g]; if (p.call(m, u, g, d)) return { i: g, v: u } } return { i: -1, v: void 0 } }; $jscomp.ASSUME_ES5 = !1; $jscomp.ASSUME_NO_NATIVE_MAP = !1; $jscomp.ASSUME_NO_NATIVE_SET = !1; $jscomp.defineProperty = $jscomp.ASSUME_ES5 || "function" == typeof Object.defineProperties ? Object.defineProperty : function (d, p, m) { d != Array.prototype && d != Object.prototype && (d[p] = m.value) };
$jscomp.getGlobal = function (d) { return "undefined" != typeof window && window === d ? d : "undefined" != typeof global && null != global ? global : d }; $jscomp.global = $jscomp.getGlobal(this); $jscomp.polyfill = function (d, p, m, l) { if (p) { m = $jscomp.global; d = d.split("."); for (l = 0; l < d.length - 1; l++) { var g = d[l]; g in m || (m[g] = {}); m = m[g] } d = d[d.length - 1]; l = m[d]; p = p(l); p != l && null != p && $jscomp.defineProperty(m, d, { configurable: !0, writable: !0, value: p }) } };
$jscomp.polyfill("Array.prototype.find", function (d) { return d ? d : function (d, m) { return $jscomp.findInternal(this, d, m).v } }, "es6", "es3");
(function (d) { "function" === typeof define && define.amd ? define(["jquery", "datatables.net"], function (p) { return d(p, window, document) }) : "object" === typeof exports ? module.exports = function (p, m) { p || (p = window); m && m.fn.dataTable || (m = require("datatables.net")(p, m).$); return d(m, p, p.document) } : d(jQuery, window, document) })(function (d, p, m, l) {
    var g = d.fn.dataTable, u = 0, B = 0, q = g.ext.buttons, r = function (a, b) {
        "undefined" === typeof b && (b = {}); !0 === b && (b = {}); d.isArray(b) && (b = { buttons: b }); this.c = d.extend(!0, {}, r.defaults, b); b.buttons &&
            (this.c.buttons = b.buttons); this.s = { dt: new g.Api(a), buttons: [], listenKeys: "", namespace: "dtb" + u++ }; this.dom = { container: d("<" + this.c.dom.container.tag + "/>").addClass(this.c.dom.container.className) }; this._constructor()
    }; d.extend(r.prototype, {
        action: function (a, b) { a = this._nodeToButton(a); if (b === l) return a.conf.action; a.conf.action = b; return this }, active: function (a, b) { var c = this._nodeToButton(a); a = this.c.dom.button.active; c = d(c.node); if (b === l) return c.hasClass(a); c.toggleClass(a, b === l ? !0 : b); return this },
        add: function (a, b) { var c = this.s.buttons; if ("string" === typeof b) { b = b.split("-"); c = this.s; for (var d = 0, f = b.length - 1; d < f; d++)c = c.buttons[1 * b[d]]; c = c.buttons; b = 1 * b[b.length - 1] } this._expandButton(c, a, !1, b); this._draw(); return this }, container: function () { return this.dom.container }, disable: function (a) { a = this._nodeToButton(a); d(a.node).addClass(this.c.dom.button.disabled); return this }, destroy: function () {
            d("body").off("keyup." + this.s.namespace); var a = this.s.buttons.slice(), b; var c = 0; for (b = a.length; c < b; c++)this.remove(a[c].node);
            this.dom.container.remove(); a = this.s.dt.settings()[0]; c = 0; for (b = a.length; c < b; c++)if (a.inst === this) { a.splice(c, 1); break } return this
        }, enable: function (a, b) { if (!1 === b) return this.disable(a); a = this._nodeToButton(a); d(a.node).removeClass(this.c.dom.button.disabled); return this }, name: function () { return this.c.name }, node: function (a) { a = this._nodeToButton(a); return d(a.node) }, processing: function (a, b) {
            a = this._nodeToButton(a); if (b === l) return d(a.node).hasClass("processing"); d(a.node).toggleClass("processing",
                b); return this
        }, remove: function (a) { var b = this._nodeToButton(a), c = this._nodeToHost(a), e = this.s.dt; if (b.buttons.length) for (var f = b.buttons.length - 1; 0 <= f; f--)this.remove(b.buttons[f].node); b.conf.destroy && b.conf.destroy.call(e.button(a), e, d(a), b.conf); this._removeKey(b.conf); d(b.node).remove(); a = d.inArray(b, c); c.splice(a, 1); return this }, text: function (a, b) {
            var c = this._nodeToButton(a); a = this.c.dom.collection.buttonLiner; a = c.inCollection && a && a.tag ? a.tag : this.c.dom.buttonLiner.tag; var e = this.s.dt, f = d(c.node),
                h = function (a) { return "function" === typeof a ? a(e, f, c.conf) : a }; if (b === l) return h(c.conf.text); c.conf.text = b; a ? f.children(a).html(h(b)) : f.html(h(b)); return this
        }, _constructor: function () {
            var a = this, b = this.s.dt, c = b.settings()[0], e = this.c.buttons; c._buttons || (c._buttons = []); c._buttons.push({ inst: this, name: this.c.name }); for (var f = 0, h = e.length; f < h; f++)this.add(e[f]); b.on("destroy", function (b, d) { d === c && a.destroy() }); d("body").on("keyup." + this.s.namespace, function (b) {
                if (!m.activeElement || m.activeElement === m.body) {
                    var c =
                        String.fromCharCode(b.keyCode).toLowerCase(); -1 !== a.s.listenKeys.toLowerCase().indexOf(c) && a._keypress(c, b)
                }
            })
        }, _addKey: function (a) { a.key && (this.s.listenKeys += d.isPlainObject(a.key) ? a.key.key : a.key) }, _draw: function (a, b) { a || (a = this.dom.container, b = this.s.buttons); a.children().detach(); for (var c = 0, d = b.length; c < d; c++)a.append(b[c].inserter), a.append(" "), b[c].buttons && b[c].buttons.length && this._draw(b[c].collection, b[c].buttons) }, _expandButton: function (a, b, c, e) {
            var f = this.s.dt, h = 0; b = d.isArray(b) ? b : [b];
            for (var k = 0, v = b.length; k < v; k++) { var n = this._resolveExtends(b[k]); if (n) if (d.isArray(n)) this._expandButton(a, n, c, e); else { var t = this._buildButton(n, c); if (t) { e !== l ? (a.splice(e, 0, t), e++) : a.push(t); if (t.conf.buttons) { var y = this.c.dom.collection; t.collection = d("<" + y.tag + "/>").addClass(y.className).attr("role", "menu"); t.conf._collection = t.collection; this._expandButton(t.buttons, t.conf.buttons, !0, e) } n.init && n.init.call(f.button(t.node), f, d(t.node), n); h++ } } }
        }, _buildButton: function (a, b) {
            var c = this.c.dom.button,
                e = this.c.dom.buttonLiner, f = this.c.dom.collection, h = this.s.dt, k = function (b) { return "function" === typeof b ? b(h, n, a) : b }; b && f.button && (c = f.button); b && f.buttonLiner && (e = f.buttonLiner); if (a.available && !a.available(h, a)) return !1; var v = function (a, b, c, e) { e.action.call(b.button(c), a, b, c, e); d(b.table().node()).triggerHandler("buttons-action.dt", [b.button(c), b, c, e]) }; f = a.tag || c.tag; var n = d("<" + f + "/>").addClass(c.className).attr("tabindex", this.s.dt.settings()[0].iTabIndex).attr("aria-controls", this.s.dt.table().node().id).on("click.dtb",
                    function (b) { b.preventDefault(); !n.hasClass(c.disabled) && a.action && v(b, h, n, a); n.blur() }).on("keyup.dtb", function (b) { 13 === b.keyCode && !n.hasClass(c.disabled) && a.action && v(b, h, n, a) }); "a" === f.toLowerCase() && n.attr("href", "#"); "button" === f.toLowerCase() && n.attr("type", "button"); e.tag ? (f = d("<" + e.tag + "/>").html(k(a.text)).addClass(e.className), "a" === e.tag.toLowerCase() && f.attr("href", "#"), n.append(f)) : n.html(k(a.text)); !1 === a.enabled && n.addClass(c.disabled); a.className && n.addClass(a.className); a.titleAttr &&
                        n.attr("title", k(a.titleAttr)); a.attr && n.attr(a.attr); a.namespace || (a.namespace = ".dt-button-" + B++); e = (e = this.c.dom.buttonContainer) && e.tag ? d("<" + e.tag + "/>").addClass(e.className).append(n) : n; this._addKey(a); return { conf: a, node: n.get(0), inserter: e, buttons: [], inCollection: b, collection: null }
        }, _nodeToButton: function (a, b) { b || (b = this.s.buttons); for (var c = 0, d = b.length; c < d; c++) { if (b[c].node === a) return b[c]; if (b[c].buttons.length) { var f = this._nodeToButton(a, b[c].buttons); if (f) return f } } }, _nodeToHost: function (a,
            b) { b || (b = this.s.buttons); for (var c = 0, d = b.length; c < d; c++) { if (b[c].node === a) return b; if (b[c].buttons.length) { var f = this._nodeToHost(a, b[c].buttons); if (f) return f } } }, _keypress: function (a, b) {
                if (!b._buttonsHandled) {
                    var c = function (e) {
                        for (var f = 0, h = e.length; f < h; f++) {
                            var k = e[f].conf, v = e[f].node; k.key && (k.key === a ? (b._buttonsHandled = !0, d(v).click()) : !d.isPlainObject(k.key) || k.key.key !== a || k.key.shiftKey && !b.shiftKey || k.key.altKey && !b.altKey || k.key.ctrlKey && !b.ctrlKey || k.key.metaKey && !b.metaKey || (b._buttonsHandled =
                                !0, d(v).click())); e[f].buttons.length && c(e[f].buttons)
                        }
                    }; c(this.s.buttons)
                }
            }, _removeKey: function (a) { if (a.key) { var b = d.isPlainObject(a.key) ? a.key.key : a.key; a = this.s.listenKeys.split(""); b = d.inArray(b, a); a.splice(b, 1); this.s.listenKeys = a.join("") } }, _resolveExtends: function (a) {
                var b = this.s.dt, c, e = function (c) {
                    for (var e = 0; !d.isPlainObject(c) && !d.isArray(c);) {
                        if (c === l) return; if ("function" === typeof c) { if (c = c(b, a), !c) return !1 } else if ("string" === typeof c) { if (!q[c]) throw "Unknown button type: " + c; c = q[c] } e++;
                        if (30 < e) throw "Buttons: Too many iterations";
                    } return d.isArray(c) ? c : d.extend({}, c)
                }; for (a = e(a); a && a.extend;) {
                    if (!q[a.extend]) throw "Cannot extend unknown button type: " + a.extend; var f = e(q[a.extend]); if (d.isArray(f)) return f; if (!f) return !1; var h = f.className; a = d.extend({}, f, a); h && a.className !== h && (a.className = h + " " + a.className); var k = a.postfixButtons; if (k) { a.buttons || (a.buttons = []); h = 0; for (c = k.length; h < c; h++)a.buttons.push(k[h]); a.postfixButtons = null } if (k = a.prefixButtons) {
                        a.buttons || (a.buttons = []); h =
                            0; for (c = k.length; h < c; h++)a.buttons.splice(h, 0, k[h]); a.prefixButtons = null
                    } a.extend = f.extend
                } return a
            }
    }); r.background = function (a, b, c, e) { c === l && (c = 400); e || (e = m.body); a ? d("<div/>").addClass(b).css("display", "none").insertAfter(e).fadeIn(c) : d("div." + b).fadeOut(c, function () { d(this).removeClass(b).remove() }) }; r.instanceSelector = function (a, b) {
        if (!a) return d.map(b, function (a) { return a.inst }); var c = [], e = d.map(b, function (a) { return a.name }), f = function (a) {
            if (d.isArray(a)) for (var k = 0, v = a.length; k < v; k++)f(a[k]);
            else "string" === typeof a ? -1 !== a.indexOf(",") ? f(a.split(",")) : (a = d.inArray(d.trim(a), e), -1 !== a && c.push(b[a].inst)) : "number" === typeof a && c.push(b[a].inst)
        }; f(a); return c
    }; r.buttonSelector = function (a, b) {
        for (var c = [], e = function (a, b, c) { for (var d, f, k = 0, h = b.length; k < h; k++)if (d = b[k]) f = c !== l ? c + k : k + "", a.push({ node: d.node, name: d.conf.name, idx: f }), d.buttons && e(a, d.buttons, f + "-") }, f = function (a, b) {
            var k, h = []; e(h, b.s.buttons); var g = d.map(h, function (a) { return a.node }); if (d.isArray(a) || a instanceof d) for (g = 0, k = a.length; g <
                k; g++)f(a[g], b); else if (null === a || a === l || "*" === a) for (g = 0, k = h.length; g < k; g++)c.push({ inst: b, node: h[g].node }); else if ("number" === typeof a) c.push({ inst: b, node: b.s.buttons[a].node }); else if ("string" === typeof a) if (-1 !== a.indexOf(",")) for (h = a.split(","), g = 0, k = h.length; g < k; g++)f(d.trim(h[g]), b); else if (a.match(/^\d+(\-\d+)*$/)) g = d.map(h, function (a) { return a.idx }), c.push({ inst: b, node: h[d.inArray(a, g)].node }); else if (-1 !== a.indexOf(":name")) for (a = a.replace(":name", ""), g = 0, k = h.length; g < k; g++)h[g].name === a &&
                    c.push({ inst: b, node: h[g].node }); else d(g).filter(a).each(function () { c.push({ inst: b, node: this }) }); else "object" === typeof a && a.nodeName && (h = d.inArray(a, g), -1 !== h && c.push({ inst: b, node: g[h] }))
        }, h = 0, k = a.length; h < k; h++)f(b, a[h]); return c
    }; r.defaults = {
        buttons: ["copy", "excel", "csv", "pdf", "print"], name: "main", tabIndex: 0, dom: {
            container: { tag: "div", className: "dt-buttons" }, collection: { tag: "div", className: "dt-button-collection" }, button: {
                tag: "ActiveXObject" in p ? "a" : "button", className: "dt-button", active: "active",
                disabled: "disabled"
            }, buttonLiner: { tag: "span", className: "" }
        }
    }; r.version = "1.5.4"; d.extend(q, {
        collection: {
            text: function (a) { return a.i18n("buttons.collection", "Collection") }, className: "buttons-collection", action: function (a, b, c, e) {
                var f = d(c).parents("div.dt-button-collection"); a = c.position(); var h = d(b.table().container()), k = !1, g = c; f.length && (k = d(".dt-button-collection").position(), g = f, d("body").trigger("click.dtb-collection")); g.parents("body")[0] !== m.body && (g = m.body.lastChild); e._collection.find(".dt-button-collection-title").remove();
                e._collection.prepend('<div class="dt-button-collection-title">' + e.collectionTitle + "</div>"); e._collection.addClass(e.collectionLayout).css("display", "none").insertAfter(g).fadeIn(e.fade); f = e._collection.css("position"); if (k && "absolute" === f) e._collection.css({ top: k.top, left: k.left }); else if ("absolute" === f) {
                    e._collection.css({ top: a.top + c.outerHeight(), left: a.left }); k = h.offset().top + h.height(); k = a.top + c.outerHeight() + e._collection.outerHeight() - k; f = a.top - e._collection.outerHeight(); var n = h.offset().top;
                    (k > n - f || e.dropup) && e._collection.css("top", a.top - e._collection.outerHeight() - 5); e._collection.hasClass(e.rightAlignClassName) && e._collection.css("left", a.left + c.outerWidth() - e._collection.outerWidth()); k = a.left + e._collection.outerWidth(); h = h.offset().left + h.width(); k > h && e._collection.css("left", a.left - (k - h)); c = c.offset().left + e._collection.outerWidth(); c > d(p).width() && e._collection.css("left", a.left - (c - d(p).width()))
                } else c = e._collection.height() / 2, c > d(p).height() / 2 && (c = d(p).height() / 2), e._collection.css("marginTop",
                    -1 * c); e.background && r.background(!0, e.backgroundClassName, e.fade, g); var l = function () { e._collection.fadeOut(e.fade, function () { e._collection.detach() }); d("div.dt-button-background").off("click.dtb-collection"); r.background(!1, e.backgroundClassName, e.fade, g); d("body").off(".dtb-collection"); b.off("buttons-action.b-internal") }; setTimeout(function () {
                        d("div.dt-button-background").on("click.dtb-collection", function () { }); d("body").on("click.dtb-collection", function (a) {
                            var b = d.fn.addBack ? "addBack" : "andSelf";
                            d(a.target).parents()[b]().filter(e._collection).length || l()
                        }).on("keyup.dtb-collection", function (a) { 27 === a.keyCode && l() }); if (e.autoClose) b.on("buttons-action.b-internal", function () { l() })
                    }, 10)
            }, background: !0, collectionLayout: "", collectionTitle: "", backgroundClassName: "dt-button-background", rightAlignClassName: "dt-button-right", autoClose: !1, fade: 400, attr: { "aria-haspopup": !0 }
        }, copy: function (a, b) { if (q.copyHtml5) return "copyHtml5"; if (q.copyFlash && q.copyFlash.available(a, b)) return "copyFlash" }, csv: function (a,
            b) { if (q.csvHtml5 && q.csvHtml5.available(a, b)) return "csvHtml5"; if (q.csvFlash && q.csvFlash.available(a, b)) return "csvFlash" }, excel: function (a, b) { if (q.excelHtml5 && q.excelHtml5.available(a, b)) return "excelHtml5"; if (q.excelFlash && q.excelFlash.available(a, b)) return "excelFlash" }, pdf: function (a, b) { if (q.pdfHtml5 && q.pdfHtml5.available(a, b)) return "pdfHtml5"; if (q.pdfFlash && q.pdfFlash.available(a, b)) return "pdfFlash" }, pageLength: function (a) {
                a = a.settings()[0].aLengthMenu; var b = d.isArray(a[0]) ? a[0] : a, c = d.isArray(a[0]) ?
                    a[1] : a, e = function (a) { return a.i18n("buttons.pageLength", { "-1": "Show all rows", _: "Show %d rows" }, a.page.len()) }; return {
                        extend: "collection", text: e, className: "buttons-page-length", autoClose: !0, buttons: d.map(b, function (a, b) { return { text: c[b], className: "button-page-length", action: function (b, c) { c.page.len(a).draw() }, init: function (b, c, d) { var e = this; c = function () { e.active(b.page.len() === a) }; b.on("length.dt" + d.namespace, c); c() }, destroy: function (a, b, c) { a.off("length.dt" + c.namespace) } } }), init: function (a, b, c) {
                            var d =
                                this; a.on("length.dt" + c.namespace, function () { d.text(e(a)) })
                        }, destroy: function (a, b, c) { a.off("length.dt" + c.namespace) }
                    }
            }
    }); g.Api.register("buttons()", function (a, b) { b === l && (b = a, a = l); this.selector.buttonGroup = a; var c = this.iterator(!0, "table", function (c) { if (c._buttons) return r.buttonSelector(r.instanceSelector(a, c._buttons), b) }, !0); c._groupSelector = a; return c }); g.Api.register("button()", function (a, b) { a = this.buttons(a, b); 1 < a.length && a.splice(1, a.length); return a }); g.Api.registerPlural("buttons().active()",
        "button().active()", function (a) { return a === l ? this.map(function (a) { return a.inst.active(a.node) }) : this.each(function (b) { b.inst.active(b.node, a) }) }); g.Api.registerPlural("buttons().action()", "button().action()", function (a) { return a === l ? this.map(function (a) { return a.inst.action(a.node) }) : this.each(function (b) { b.inst.action(b.node, a) }) }); g.Api.register(["buttons().enable()", "button().enable()"], function (a) { return this.each(function (b) { b.inst.enable(b.node, a) }) }); g.Api.register(["buttons().disable()",
            "button().disable()"], function () { return this.each(function (a) { a.inst.disable(a.node) }) }); g.Api.registerPlural("buttons().nodes()", "button().node()", function () { var a = d(); d(this.each(function (b) { a = a.add(b.inst.node(b.node)) })); return a }); g.Api.registerPlural("buttons().processing()", "button().processing()", function (a) { return a === l ? this.map(function (a) { return a.inst.processing(a.node) }) : this.each(function (b) { b.inst.processing(b.node, a) }) }); g.Api.registerPlural("buttons().text()", "button().text()", function (a) {
                return a ===
                    l ? this.map(function (a) { return a.inst.text(a.node) }) : this.each(function (b) { b.inst.text(b.node, a) })
            }); g.Api.registerPlural("buttons().trigger()", "button().trigger()", function () { return this.each(function (a) { a.inst.node(a.node).trigger("click") }) }); g.Api.registerPlural("buttons().containers()", "buttons().container()", function () {
                var a = d(), b = this._groupSelector; this.iterator(!0, "table", function (c) { if (c._buttons) { c = r.instanceSelector(b, c._buttons); for (var d = 0, f = c.length; d < f; d++)a = a.add(c[d].container()) } });
                return a
            }); g.Api.register("button().add()", function (a, b) { var c = this.context; c.length && (c = r.instanceSelector(this._groupSelector, c[0]._buttons), c.length && c[0].add(b, a)); return this.button(this._groupSelector, a) }); g.Api.register("buttons().destroy()", function () { this.pluck("inst").unique().each(function (a) { a.destroy() }); return this }); g.Api.registerPlural("buttons().remove()", "buttons().remove()", function () { this.each(function (a) { a.inst.remove(a.node) }); return this }); var w; g.Api.register("buttons.info()",
                function (a, b, c) {
                    var e = this; if (!1 === a) return d("#datatables_buttons_info").fadeOut(function () { d(this).remove() }), clearTimeout(w), w = null, this; w && clearTimeout(w); d("#datatables_buttons_info").length && d("#datatables_buttons_info").remove(); a = a ? "<h2>" + a + "</h2>" : ""; d('<div id="datatables_buttons_info" class="dt-button-info"/>').html(a).append(d("<div/>")["string" === typeof b ? "html" : "append"](b)).css("display", "none").appendTo("body").fadeIn(); c !== l && 0 !== c && (w = setTimeout(function () { e.buttons.info(!1) }, c));
                    return this
                }); g.Api.register("buttons.exportData()", function (a) { if (this.context.length) return C(new g.Api(this.context[0]), a) }); g.Api.register("buttons.exportInfo()", function (a) {
                    a || (a = {}); var b = a; var c = "*" === b.filename && "*" !== b.title && b.title !== l && null !== b.title && "" !== b.title ? b.title : b.filename; "function" === typeof c && (c = c()); c === l || null === c ? c = null : (-1 !== c.indexOf("*") && (c = d.trim(c.replace("*", d("head > title").text()))), c = c.replace(/[^a-zA-Z0-9_\u00A1-\uFFFF\.,\-_ !\(\)]/g, ""), (b = x(b.extension)) ||
                        (b = ""), c += b); b = x(a.title); b = null === b ? null : -1 !== b.indexOf("*") ? b.replace("*", d("head > title").text() || "Exported data") : b; return { filename: c, title: b, messageTop: z(this, a.message || a.messageTop, "top"), messageBottom: z(this, a.messageBottom, "bottom") }
                }); var x = function (a) { return null === a || a === l ? null : "function" === typeof a ? a() : a }, z = function (a, b, c) { b = x(b); if (null === b) return null; a = d("caption", a.table().container()).eq(0); return "*" === b ? a.css("caption-side") !== c ? null : a.length ? a.text() : "" : b }, A = d("<textarea/>")[0],
                    C = function (a, b) {
                        var c = d.extend(!0, {}, { rows: null, columns: "", modifier: { search: "applied", order: "applied" }, orthogonal: "display", stripHtml: !0, stripNewlines: !0, decodeEntities: !0, trim: !0, format: { header: function (a) { return e(a) }, footer: function (a) { return e(a) }, body: function (a) { return e(a) } }, customizeData: null }, b), e = function (a) {
                            if ("string" !== typeof a) return a; a = a.replace(/<script\b[^<]*(?:(?!<\/script>)<[^<]*)*<\/script>/gi, ""); a = a.replace(/<!\-\-.*?\-\->/g, ""); c.stripHtml && (a = a.replace(/<[^>]*>/g, "")); c.trim &&
                                (a = a.replace(/^\s+|\s+$/g, "")); c.stripNewlines && (a = a.replace(/\n/g, " ")); c.decodeEntities && (A.innerHTML = a, a = A.value); return a
                        }; b = a.columns(c.columns).indexes().map(function (b) { var d = a.column(b).header(); return c.format.header(d.innerHTML, b, d) }).toArray(); var f = a.table().footer() ? a.columns(c.columns).indexes().map(function (b) { var d = a.column(b).footer(); return c.format.footer(d ? d.innerHTML : "", b, d) }).toArray() : null, h = d.extend({}, c.modifier); a.select && "function" === typeof a.select.info && h.selected === l &&
                            a.rows(c.rows, d.extend({ selected: !0 }, h)).any() && d.extend(h, { selected: !0 }); h = a.rows(c.rows, h).indexes().toArray(); var g = a.cells(h, c.columns); h = g.render(c.orthogonal).toArray(); g = g.nodes().toArray(); for (var m = b.length, n = [], p = 0, q = 0, r = 0 < m ? h.length / m : 0; q < r; q++) { for (var w = [m], u = 0; u < m; u++)w[u] = c.format.body(h[p], q, u, g[p]), p++; n[q] = w } b = { header: b, footer: f, body: n }; c.customizeData && c.customizeData(b); return b
                    }; d.fn.dataTable.Buttons = r; d.fn.DataTable.Buttons = r; d(m).on("init.dt plugin-init.dt", function (a, b) {
                        "dt" ===
                            a.namespace && (a = b.oInit.buttons || g.defaults.buttons) && !b._buttons && (new r(b, a)).container()
                    }); g.ext.feature.push({ fnInit: function (a) { a = new g.Api(a); var b = a.init().buttons || g.defaults.buttons; return (new r(a, b)).container() }, cFeature: "B" }); return r
});