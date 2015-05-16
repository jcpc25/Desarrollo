// page init
$(function(){
	initTouchNav();
	initMultiColumns();
});

// handle dropdowns on mobile devices
function initTouchNav() {
	$('.nav').each(function(){
		new TouchNav({
			navBlock: this
		});
	});
}

// split content into columns
function initMultiColumns() {
	$('.article-content').columnize({
		buildOnce: true,
		columns: 2
	});
}

// navigation accesibility module
function TouchNav(opt) {
	this.options = {
		hoverClass: 'hover',
		menuItems: 'li',
		menuOpener: 'a',
		menuDrop: 'ul',
		navBlock: null
	};
	for(var p in opt) {
		if(opt.hasOwnProperty(p)) {
			this.options[p] = opt[p];
		}
	}
	this.init();
}
TouchNav.isActiveOn = function(elem) {
	return elem && elem.touchNavActive;
};
TouchNav.prototype = {
	init: function() {
		if(typeof this.options.navBlock === 'string') {
			this.menu = document.getElementById(this.options.navBlock);
		} else if(typeof this.options.navBlock === 'object') {
			this.menu = this.options.navBlock;
		}
		if(this.menu) {
			this.addEvents();
		}
	},
	addEvents: function() {
		// attach event handlers
		var self = this;
		var touchEvent = (navigator.pointerEnabled && 'pointerdown') || (navigator.msPointerEnabled && 'MSPointerDown') || (this.isTouchDevice && 'touchstart');
		this.menuItems = lib.queryElementsBySelector(this.options.menuItems, this.menu);

		var initMenuItem = function(item) {
			var currentDrop = lib.queryElementsBySelector(self.options.menuDrop, item)[0],
				currentOpener = lib.queryElementsBySelector(self.options.menuOpener, item)[0];

			// only for touch input devices
			if( currentDrop && currentOpener && (self.isTouchDevice || self.isPointerDevice) ) {
				lib.event.add(currentOpener, 'click', lib.bind(self.clickHandler, self));
				lib.event.add(currentOpener, 'mousedown', lib.bind(self.mousedownHandler, self));
				lib.event.add(currentOpener, touchEvent, function(e){
					if( !self.isTouchPointerEvent(e) ) {
						self.preventCurrentClick = false;
						return;
					}
					self.touchFlag = true;
					self.currentItem = item;
					self.currentLink = currentOpener;
					self.pressHandler.apply(self, arguments);
				});
			}
			// for desktop computers and touch devices
			$(item).bind('mouseenter', function(){
				if(!self.touchFlag) {
					self.currentItem = item;
					self.mouseoverHandler();
				}
			});
			$(item).bind('mouseleave', function(){
				if(!self.touchFlag) {
					self.currentItem = item;
					self.mouseoutHandler();
				}
			});
			item.touchNavActive = true;
		};

		// addd handlers for all menu items
		for(var i = 0; i < this.menuItems.length; i++) {
			initMenuItem(self.menuItems[i]);
		}

		// hide dropdowns when clicking outside navigation
		if(this.isTouchDevice || this.isPointerDevice) {
			lib.event.add(document.body, 'mousedown', lib.bind(this.clickOutsideHandler, this));
			lib.event.add(document.body, touchEvent, lib.bind(this.clickOutsideHandler, this));
		}
	},
	mousedownHandler: function(e) {
		if(this.touchFlag) {
			e.preventDefault();
			this.touchFlag = false;
			this.preventCurrentClick = false;
		}
	},
	mouseoverHandler: function() {
		lib.addClass(this.currentItem, this.options.hoverClass);
		$(this.currentItem).trigger('itemhover');
	},
	mouseoutHandler: function() {
		lib.removeClass(this.currentItem, this.options.hoverClass);
		$(this.currentItem).trigger('itemleave');
	},
	hideActiveDropdown: function() {
		for(var i = 0; i < this.menuItems.length; i++) {
			if(lib.hasClass(this.menuItems[i], this.options.hoverClass)) {
				lib.removeClass(this.menuItems[i], this.options.hoverClass);
				$(this.menuItems[i]).trigger('itemleave');
			}
		}
		this.activeParent = null;
	},
	pressHandler: function(e) {
		// hide previous drop (if active)
		if(this.currentItem !== this.activeParent) {
			if(this.activeParent && this.currentItem.parentNode === this.activeParent.parentNode) {
				lib.removeClass(this.activeParent, this.options.hoverClass);
			} else if(!this.isParent(this.activeParent, this.currentLink)) {
				this.hideActiveDropdown();
			}
		}
		// handle current drop
		this.activeParent = this.currentItem;
		if(lib.hasClass(this.currentItem, this.options.hoverClass)) {
			this.preventCurrentClick = false;
		} else {
			e.preventDefault();
			this.preventCurrentClick = true;
			lib.addClass(this.currentItem, this.options.hoverClass);
			$(this.currentItem).trigger('itemhover');
		}
	},
	clickHandler: function(e) {
		// prevent first click on link
		if(this.preventCurrentClick) {
			e.preventDefault();
		}
	},
	clickOutsideHandler: function(event) {
		var e = event.changedTouches ? event.changedTouches[0] : event;
		if(this.activeParent && !this.isParent(this.menu, e.target)) {
			this.hideActiveDropdown();
			this.touchFlag = false;
		}
	},
	isParent: function(parent, child) {
		while(child.parentNode) {
			if(child.parentNode == parent) {
				return true;
			}
			child = child.parentNode;
		}
		return false;
	},
	isTouchPointerEvent: function(e) {
		return (e.type.indexOf('touch') > -1) ||
				(navigator.pointerEnabled && e.pointerType === 'touch') ||
				(navigator.msPointerEnabled && e.pointerType == e.MSPOINTER_TYPE_TOUCH);
	},
	isPointerDevice: (function() {
		return !!(navigator.pointerEnabled || navigator.msPointerEnabled);
	}()),
	isTouchDevice: (function() {
		return !!(('ontouchstart' in window) || window.DocumentTouch && document instanceof DocumentTouch);
	}())
};

/*
 * Utility module
 */
lib = {
	hasClass: function(el,cls) {
		return el && el.className ? el.className.match(new RegExp('(\\s|^)'+cls+'(\\s|$)')) : false;
	},
	addClass: function(el,cls) {
		if (el && !this.hasClass(el,cls)) el.className += " "+cls;
	},
	removeClass: function(el,cls) {
		if (el && this.hasClass(el,cls)) {el.className=el.className.replace(new RegExp('(\\s|^)'+cls+'(\\s|$)'),' ');}
	},
	extend: function(obj) {
		for(var i = 1; i < arguments.length; i++) {
			for(var p in arguments[i]) {
				if(arguments[i].hasOwnProperty(p)) {
					obj[p] = arguments[i][p];
				}
			}
		}
		return obj;
	},
	each: function(obj, callback) {
		var property, len;
		if(typeof obj.length === 'number') {
			for(property = 0, len = obj.length; property < len; property++) {
				if(callback.call(obj[property], property, obj[property]) === false) {
					break;
				}
			}
		} else {
			for(property in obj) {
				if(obj.hasOwnProperty(property)) {
					if(callback.call(obj[property], property, obj[property]) === false) {
						break;
					}
				}
			}
		}
	},
	event: (function() {
		var fixEvent = function(e) {
			e = e || window.event;
			if(e.isFixed) return e; else e.isFixed = true;
			if(!e.target) e.target = e.srcElement;
			e.preventDefault = e.preventDefault || function() {this.returnValue = false;};
			e.stopPropagation = e.stopPropagation || function() {this.cancelBubble = true;};
			return e;
		};
		return {
			add: function(elem, event, handler) {
				if(!elem.events) {
					elem.events = {};
					elem.handle = function(e) {
						var ret, handlers = elem.events[e.type];
						e = fixEvent(e);
						for(var i = 0, len = handlers.length; i < len; i++) {
							if(handlers[i]) {
								ret = handlers[i].call(elem, e);
								if(ret === false) {
									e.preventDefault();
									e.stopPropagation();
								}
							}
						}
					};
				}
				if(!elem.events[event]) {
					elem.events[event] = [];
					if(elem.addEventListener) elem.addEventListener(event, elem.handle, false);
					else if(elem.attachEvent) elem.attachEvent('on'+event, elem.handle);
				}
				elem.events[event].push(handler);
			},
			remove: function(elem, event, handler) {
				var handlers = elem.events[event];
				for(var i = handlers.length - 1; i >= 0; i--) {
					if(handlers[i] === handler) {
						handlers.splice(i,1);
					}
				}
				if(!handlers.length) {
					delete elem.events[event];
					if(elem.removeEventListener) elem.removeEventListener(event, elem.handle, false);
					else if(elem.detachEvent) elem.detachEvent('on'+event, elem.handle);
				}
			}
		};
	}()),
	queryElementsBySelector: function(selector, scope) {
		scope = scope || document;
		if(!selector) return [];
		if(selector === '>*') return scope.children;
		if(typeof document.querySelectorAll === 'function') {
			return scope.querySelectorAll(selector);
		}
		var selectors = selector.split(',');
		var resultList = [];
		for(var s = 0; s < selectors.length; s++) {
			var currentContext = [scope || document];
			var tokens = selectors[s].replace(/^\s+/,'').replace(/\s+$/,'').split(' ');
			for (var i = 0; i < tokens.length; i++) {
				token = tokens[i].replace(/^\s+/,'').replace(/\s+$/,'');
				if (token.indexOf('#') > -1) {
					var bits = token.split('#'), tagName = bits[0], id = bits[1];
					var element = document.getElementById(id);
					if (element && tagName && element.nodeName.toLowerCase() != tagName) {
						return [];
					}
					currentContext = element ? [element] : [];
					continue;
				}
				if (token.indexOf('.') > -1) {
					var bits = token.split('.'), tagName = bits[0] || '*', className = bits[1], found = [], foundCount = 0;
					for (var h = 0; h < currentContext.length; h++) {
						var elements;
						if (tagName == '*') {
							elements = currentContext[h].getElementsByTagName('*');
						} else {
							elements = currentContext[h].getElementsByTagName(tagName);
						}
						for (var j = 0; j < elements.length; j++) {
							found[foundCount++] = elements[j];
						}
					}
					currentContext = [];
					var currentContextIndex = 0;
					for (var k = 0; k < found.length; k++) {
						if (found[k].className && found[k].className.match(new RegExp('(\\s|^)'+className+'(\\s|$)'))) {
							currentContext[currentContextIndex++] = found[k];
						}
					}
					continue;
				}
				if (token.match(/^(\w*)\[(\w+)([=~\|\^\$\*]?)=?"?([^\]"]*)"?\]$/)) {
					var tagName = RegExp.$1 || '*', attrName = RegExp.$2, attrOperator = RegExp.$3, attrValue = RegExp.$4;
					if(attrName.toLowerCase() == 'for' && this.browser.msie && this.browser.version < 8) {
						attrName = 'htmlFor';
					}
					var found = [], foundCount = 0;
					for (var h = 0; h < currentContext.length; h++) {
						var elements;
						if (tagName == '*') {
							elements = currentContext[h].getElementsByTagName('*');
						} else {
							elements = currentContext[h].getElementsByTagName(tagName);
						}
						for (var j = 0; elements[j]; j++) {
							found[foundCount++] = elements[j];
						}
					}
					currentContext = [];
					var currentContextIndex = 0, checkFunction;
					switch (attrOperator) {
						case '=': checkFunction = function(e) { return (e.getAttribute(attrName) == attrValue) }; break;
						case '~': checkFunction = function(e) { return (e.getAttribute(attrName).match(new RegExp('(\\s|^)'+attrValue+'(\\s|$)'))) }; break;
						case '|': checkFunction = function(e) { return (e.getAttribute(attrName).match(new RegExp('^'+attrValue+'-?'))) }; break;
						case '^': checkFunction = function(e) { return (e.getAttribute(attrName).indexOf(attrValue) == 0) }; break;
						case '$': checkFunction = function(e) { return (e.getAttribute(attrName).lastIndexOf(attrValue) == e.getAttribute(attrName).length - attrValue.length) }; break;
						case '*': checkFunction = function(e) { return (e.getAttribute(attrName).indexOf(attrValue) > -1) }; break;
						default : checkFunction = function(e) { return e.getAttribute(attrName) };
					}
					currentContext = [];
					var currentContextIndex = 0;
					for (var k = 0; k < found.length; k++) {
						if (checkFunction(found[k])) {
							currentContext[currentContextIndex++] = found[k];
						}
					}
					continue;
				}
				tagName = token;
				var found = [], foundCount = 0;
				for (var h = 0; h < currentContext.length; h++) {
					var elements = currentContext[h].getElementsByTagName(tagName);
					for (var j = 0; j < elements.length; j++) {
						found[foundCount++] = elements[j];
					}
				}
				currentContext = found;
			}
			resultList = [].concat(resultList,currentContext);
		}
		return resultList;
	},
	trim: function (str) {
		return str.replace(/^\s+/, '').replace(/\s+$/, '');
	},
	bind: function(f, scope, forceArgs){
		return function() {return f.apply(scope, typeof forceArgs !== 'undefined' ? [forceArgs] : arguments);};
	}
};

// version 1.6.0
// http://welcome.totheinter.net/columnizer-jquery-plugin/
// created by: Adam Wulf @adamwulf, adam.wulf@gmail.com
;(function(e){e.fn.columnize=function(t){var n={width:400,columns:!1,buildOnce:!1,overflow:!1,doneFunc:function(){},target:!1,ignoreImageLoading:!0,columnFloat:"left",lastNeverTallest:!1,accuracy:!1,manualBreaks:!1,cssClassPrefix:""},t=e.extend(n,t);return typeof t.width=="string"&&(t.width=parseInt(t.width),isNaN(t.width)&&(t.width=n.width)),this.each(function(){function h(e,t){var n=t?".":"";return f.length?n+f+"-"+e:n+e}function p(n,r,i,s){while((a||i.height()<s)&&r[0].childNodes.length){var o=r[0].childNodes[0];if(e(o).find(h("columnbreak",!0)).length)return;if(e(o).hasClass(h("columnbreak")))return;n.append(o)}if(n[0].childNodes.length==0)return;var u=n[0].childNodes,f=u[u.length-1];n[0].removeChild(f);var l=e(f);if(l[0].nodeType==3){var c=l[0].nodeValue,p=t.width/18;t.accuracy&&(p=t.accuracy);var d,v=null;while(i.height()<s&&c.length){var m=c.indexOf(" ",p);m!=-1?d=c.substring(0,c.indexOf(" ",p)):d=c,v=document.createTextNode(d),n.append(v),c.length>p&&m!=-1?c=c.substring(m):c=""}i.height()>=s&&v!=null&&(n[0].removeChild(v),c=v.nodeValue+c);if(!c.length)return!1;l[0].nodeValue=c}return r.contents().length?r.prepend(l):r.append(l),l[0].nodeType==3}function d(e,t,n,r){if(e.contents(":last").find(h("columnbreak",!0)).length)return;if(e.contents(":last").hasClass(h("columnbreak")))return;if(t.contents().length){var i=t.contents(":first");if(i.get(0).nodeType!=1)return;var s=i.clone(!0);i.hasClass(h("columnbreak"))?(e.append(s),i.remove()):a?(e.append(s),i.remove()):s.get(0).nodeType==1&&!s.hasClass(h("dontend"))&&(e.append(s),s.is("img")&&n.height()<r+20?i.remove():!i.hasClass(h("dontsplit"))&&n.height()<r+20?i.remove():s.is("img")||i.hasClass(h("dontsplit"))?s.remove():(s.empty(),p(s,i,n,r)?i.addClass(h("split")):(i.addClass(h("split")),i.children().length&&d(s,i,n,r)),s.get(0).childNodes.length==0&&s.remove()))}}function v(){if(r.data("columnized")&&r.children().length==1)return;r.data("columnized",!0),r.data("columnizing",!0),r.empty(),r.append(e("<div class='"+h("first")+" "+h("last")+" "+h("column")+" "+"' style='width:100%; float: "+t.columnFloat+";'></div>")),$col=r.children().eq(r.children().length-1),$destroyable=s.clone(!0);if(t.overflow){targetHeight=t.overflow.height,p($col,$destroyable,$col,targetHeight),$destroyable.contents().find(":first-child").hasClass(h("dontend"))||d($col,$destroyable,$col,targetHeight);while($col.contents(":last").length&&m($col.contents(":last").get(0))){var n=$col.contents(":last");n.remove(),$destroyable.prepend(n)}var i="",o=document.createElement("DIV");while($destroyable[0].childNodes.length>0){var u=$destroyable[0].childNodes[0];if(u.attributes)for(var a=0;a<u.attributes.length;a++)u.attributes[a].nodeName.indexOf("jQuery")==0&&u.removeAttribute(u.attributes[a].nodeName);o.innerHTML="",o.appendChild($destroyable[0].childNodes[0]),i+=o.innerHTML}var f=e(t.overflow.id)[0];f.innerHTML=i}else $col.append($destroyable);r.data("columnizing",!1),t.overflow&&t.overflow.doneFunc&&t.overflow.doneFunc()}function m(t){if(t.nodeType==3)return/^\s+$/.test(t.nodeValue)?t.previousSibling?m(t.previousSibling):!1:!1;return t.nodeType!=1?!1:e(t).hasClass(h("dontend"))?!0:t.childNodes.length==0?!1:m(t.childNodes[t.childNodes.length-1])}function g(){l=0;if(o==r.width())return;o=r.width();var n=Math.round(r.width()/t.width),u=t.width,f=t.height;t.columns&&(n=t.columns),a&&(n=s.find(h("columnbreak",!0)).length+1,u=!1);if(n<=1)return v();if(r.data("columnizing"))return;r.data("columnized",!0),r.data("columnizing",!0),r.empty(),r.append(e("<div style='width:"+Math.floor(100/n)+"%; float: "+t.columnFloat+";'></div>")),N=r.children(":last"),N.append(s.clone()),i=N.height(),r.empty();var c=i/n,g=!0,y=3,b=!1;t.overflow?(y=1,c=t.overflow.height):f&&u&&(y=1,c=f,b=!0);for(var w=0;w<y&&y<20;w++){r.empty();var E;try{E=s.clone(!0)}catch(S){E=s.clone()}E.css("visibility","hidden");for(var x=0;x<n;x++){var T=x==0?h("first"):"";T+=" "+h("column");var T=x==n-1?h("last")+" "+T:T;r.append(e("<div class='"+T+"' style='width:"+Math.floor(100/n)+"%; float: "+t.columnFloat+";'></div>"))}var x=0;while(x<n-(t.overflow?0:1)||b&&E.contents().length){r.children().length<=x&&r.append(e("<div class='"+T+"' style='width:"+Math.floor(100/n)+"%; float: "+t.columnFloat+";'></div>"));var N=r.children().eq(x);p(N,E,N,c),d(N,E,N,c);while(N.contents(":last").length&&m(N.contents(":last").get(0))){var C=N.contents(":last");C.remove(),E.prepend(C)}x++,N.contents().length==0&&E.contents().length?N.append(E.contents(":first")):x==n-(t.overflow?0:1)&&!t.overflow&&E.find(h("columnbreak",!0)).length&&n++}if(t.overflow&&!b){var k=!1,L=document.all&&navigator.appVersion.indexOf("MSIE 7.")!=-1;if(k||L){var A="",O=document.createElement("DIV");while(E[0].childNodes.length>0){var M=E[0].childNodes[0];for(var x=0;x<M.attributes.length;x++)M.attributes[x].nodeName.indexOf("jQuery")==0&&M.removeAttribute(M.attributes[x].nodeName);O.innerHTML="",O.appendChild(E[0].childNodes[0]),A+=O.innerHTML}var _=e(t.overflow.id)[0];_.innerHTML=A}else e(t.overflow.id).empty().append(E.contents().clone(!0))}else if(!b){N=r.children().eq(r.children().length-1);while(E.contents().length)N.append(E.contents(":first"));var D=N.height(),P=D-c,H=0,B=1e7,j=0,F=!1,I=0;r.children().each(function(e){return function(t){var n=e.children().eq(t),r=n.children(":last").find(h("columnbreak",!0)).length;if(!r){var i=n.height();F=!1,H+=i,i>j&&(j=i,F=!0),i<B&&(B=i),I++}}}(r));var q=H/I;H==0?w=y:t.lastNeverTallest&&F?(l+=30,c+=30,w==y-1&&y++):j-B>30?c=q+30:Math.abs(q-c)>20?c=q:w=y}else r.children().each(function(e){N=r.children().eq(e),N.width(u+"px"),e==0?N.addClass(h("first")):e==r.children().length-1?N.addClass(h("last")):(N.removeClass(h("first")),N.removeClass(h("last")))}),r.width(r.children().length*u+"px");r.append(e("<br style='clear:both;'>"))}r.find(h("column",!0)).find(":first"+h("removeiffirst",!0)).remove(),r.find(h("column",!0)).find(":last"+h("removeiflast",!0)).remove(),r.data("columnizing",!1),t.overflow&&t.overflow.doneFunc(),t.doneFunc()}var r=t.target?e(t.target):e(this),i=e(this).height(),s=e("<div></div>"),o=0,u=!1,a=t.manualBreaks,f=n.cssClassPrefix;typeof t.cssClassPrefix=="string"&&(f=t.cssClassPrefix);var l=0;s.append(e(this).contents().clone(!0));if(!t.ignoreImageLoading&&!t.target&&!r.data("imageLoaded")){r.data("imageLoaded",!0);if(e(this).find("img").length>0){var c=function(e,n){return function(){e.data("firstImageLoaded")||(e.data("firstImageLoaded","true"),e.empty().append(n.children().clone(!0)),e.columnize(t))}}(e(this),s);e(this).find("img").one("load",c),e(this).find("img").one("abort",c);return}}r.empty(),g(),t.buildOnce||e(window).resize(function(){!t.buildOnce&&e.browser.msie?(r.data("timeout")&&clearTimeout(r.data("timeout")),r.data("timeout",setTimeout(g,200))):t.buildOnce||g()})})}})($);