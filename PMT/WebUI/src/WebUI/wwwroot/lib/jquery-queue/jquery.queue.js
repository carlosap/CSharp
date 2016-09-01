//app.service.request("/api/datasource?name=uiconfig",sucess,fail);
function Queue(ajaxQueue) {
	ajaxQueue = ajaxQueue || Array();	
	var self = this, checkAjax = null, xhr = null, connection = true, cancelNum = -1, processed = 0, lastProcessed = -1, 
	loading = false, callbacks = {}, nested = false,
		trigger = function(e, args) {
			if(callbacks[e]) {
				callbacks[e].fireWith(self, args);
			}
		},		
		getURL = function(str) {return self.baseURL + ((str.lastIndexOf('?') !== -1) ? str.substr(0, str.lastIndexOf('?')) : str);},
		getQueryData = function(url) {
			var queryData = {};			
			if(url.lastIndexOf('?') !== -1) {
				var arrKeys = (url.substr(url.lastIndexOf('?')+1)).split('&');				
				jQuery.each(arrKeys, function(i, v) {
					var arrQuery = v.split('=');
					queryData[arrQuery[0]] = arrQuery[1];
				});
			}		
			return queryData;
		};
	this.connection = {timeout: 2000, check: true, url: 'http://www.designcise.com/framework/img/chk_conn.gif'}, 
	this.timeout = 5000, this.baseURL = '', this.alwaysSend = null, this.dataType = 'json', this.cache = false, 
	this.loaderClass = 'loader', this.type = 'POST';
	this.on = function(e, callback) {
		if(!callbacks[e]) {
			callbacks[e] = jQuery.Callbacks();
			callbacks[e].add(callback);
		}		
		return this;
	}
	this.off = function(e) {
		if(!callbacks[e]) {
			return;
		}
		delete callbacks[e];
		return this;
	}
	
	this.add = function(obj, index, addAfter) {
		addAfter = addAfter || false;
		if(null == index || (index === ajaxQueue.length && addAfter)) {
			if(obj instanceof Array) {
				for(var i=0; i<obj.length; i++) {
					ajaxQueue.push(obj[i]);
				}
			}
			else {
				ajaxQueue.push(obj);
			}
		}
		else {
			index -= 1;
			if(obj instanceof Array) {
				for(var i=obj.length-1; i>=0; i--) {
					ajaxQueue.splice((index+((addAfter) ? 1 : 0)), 0, obj[i]);
				}
			}
			else {
				ajaxQueue.splice((index+((addAfter) ? 1 : 0)), 0, obj);
			}
		}		
		return this;
	}

	this.remove = function(index) {
		if(index >= 0 && index > processed && index < ajaxQueue.length) {
			ajaxQueue.splice((index-1), 1);
		}		
		return this;
	}

	this.clear = function() {
		ajaxQueue = Array();	
		return this;
	}

	this.showLoader = function(elem, opacity) {
		elem = jQuery(elem) || jQuery(document.body);
		opacity = opacity || 0.65;
		
		if(elem.css('position') === 'static') {
			elem.css('position', 'relative');
		}
		jQuery('<div class="' + self.loaderClass + '"/>').prependTo(elem).fadeTo('slow', opacity);
		
		return this;
	}

	this.hideLoader = function(elem) {
		elem = (null != elem) ? jQuery(elem).find('.' + self.loaderClass) : jQuery('.' + self.loaderClass);
		elem.fadeOut('slow', 'linear', function() {
			jQuery(this).remove();
		});
		
		return this;
	}

	this.request = function(reqData, success, error, always) {
		if(connection) {
			if(typeof reqData === 'string') {
				reqData = {url: reqData, success: success, error: error, always: always};
			}			
			loading = true;
			
			if(null != self.alwaysSend) {
				var needle = jQuery.param(self.alwaysSend); 
					needle = needle.split('&');
				
				for(var i=0; i<needle.length; i++) {
					var str = needle[i].split('='), key = str[0], value = str[1];
					
					if(reqData.url.indexOf(key + '=') === -1) {
						reqData.url = reqData.url + ((null != value) ? (((reqData.url.indexOf('?') !== -1) ? '&' : '?') + key + '=' + value) : '');
					}

				}
			}

			if(reqData.dataType === 'jsonp' || self.dataType === 'jsonp') {
				var proxyFunc = 'queueProxy' + (new Date()).getTime();
				window[proxyFunc] = function() {return false;}
			}
			
			trigger('processStart', [processed+1, getURL(reqData.url), getQueryData(reqData.url), ajaxQueue.length, (processed === lastProcessed)]);
			lastProcessed = processed;
			

			if (reqData.url.indexOf('label?') !== -1 || reqData.url.indexOf('static?') !== -1 || reqData.url.indexOf('image?') !== -1) {
			    var queryString = '';
			    var language = (app.cache.localGet("language") || app.localization.language || 'eng');
			    var indexLang = reqData.url.indexOf('&lang=');
			    if (indexLang !== -1) {
			        queryString = reqData.url.substring(indexLang, reqData.url.length);
			        reqData.url = reqData.url.replace(queryString, '');
			    } else {
			        reqData.url = reqData.url.substring(indexLang, reqData.url.length);
			    }

			    reqData.url = reqData.url + '&lang=' + language;
			}


			xhr = jQuery.ajax({
				url: self.baseURL + (reqData.url || ''),
				dataType: reqData.dataType || self.dataType,
				cache: reqData.cache || self.cache,
				jsonpCallback: proxyFunc,
				type: reqData.type || self.type,
				crossDomain: ((reqData.dataType === 'jsonp' || self.dataType === 'jsonp') ? true : false),
				timeout: reqData.timeout || self.timeout,				
				error: function(jqXHR, textStatus, errorThrown) {
					xhr = null;					
					loading = false;
					processed += 1;					
					if(textStatus === 'cancel') {
						textStatus = 'abort';
						errorThrown = 'Request Canceled';
					}
					else if(textStatus === 'stop') {
						textStatus = 'abort';
						errorThrown = 'Request Stopped';
					}
					
					if(typeof reqData.error === 'function') {
						reqData.error(processed, getURL(reqData.url), getQueryData(reqData.url), textStatus, errorThrown, ajaxQueue.length, nested);
					}
					if(typeof reqData.always === 'function') {
						reqData.always(processed, ajaxQueue.length, false, nested);
					}
					
					nested = false;
				},
				success: function(data) {
					xhr = null;					
					var temp = nested;
					nested = loading = (typeof reqData.success === 'function') ? (reqData.success(data, (processed+1), getURL(reqData.url), getQueryData(reqData.url), ajaxQueue.length, nested) || false) : false;					
					if(!loading) {
						processed += 1;
					}
					if(typeof reqData.always === 'function') {
						reqData.always(processed, ajaxQueue.length, true, temp);
					}
				}
			});
		}		
		return this;
	}

	this.cancel = function(reqNum, isNested) {
		reqNum = reqNum-1;
		isNested = (typeof isNested !== 'boolean') ? false : isNested;
		
		if(reqNum < ajaxQueue.length) {
			var waitToCancel = setInterval(function() {
				if(processed <= reqNum) {
					if(null != xhr && processed === reqNum) {
						if(isNested && !nested) {return;}
						xhr.abort('cancel');
						clearInterval(waitToCancel);
						waitToCancel = null;
					}
					else {
						if(cancelNum === -1 || cancelNum < processed) {
							if(isNested && !nested) {return;}
							cancelNum = reqNum;
						}
					}
				}
				else {
					clearInterval(waitToCancel);
					waitToCancel = null;
				}
			}, 50);

			setTimeout(function() {
				if(null != waitToCancel) {
					clearInterval(waitToCancel);
				}
			}, 25000);
		}
		
		return this;
	}
	
	this.stop = function() {
		if(null != checkAjax) {
			clearInterval(checkAjax);
			if(null != xhr) {
				xhr.abort('stop');
			}
			
			var temp = nested;
			for(var i=processed; i<ajaxQueue.length; i++) {
				if(typeof ajaxQueue[i].error === 'function') {
					ajaxQueue[i].error(i+1, getURL(ajaxQueue[i].url), getQueryData(ajaxQueue[i].url), 'abort', 'Request Stopped', ajaxQueue.length, temp);
				}
				
				temp = false;
			}
			for(var i=processed; i<ajaxQueue.length; i++) {
				if(typeof ajaxQueue[i].always === 'function') {
					ajaxQueue[i].always(i+1, ajaxQueue.length, false, nested);
				}
				
				nested = false;
			}

			trigger('complete');
			processed = ajaxQueue.length-1;
		}
		
		return this;
	}

	this.start = function() {
		if(self.isWorking()) {self.stop();}
		cancelNum = -1, processed = 0, lastProcessed = -1, loading = false;
		trigger('init');
		var connectionChecked = false;	
		if(self.connection.check) {
			var temp = document.createElement('img'), established = false;
			var checkConn = setTimeout(function() {
				connection = established;				
				connectionChecked = true;
			}, self.connection.timeout);
			temp.src = self.connection.url;
			temp.onerror = function() {connection = false; connectionChecked = true; clearTimeout(checkConn);}
			temp.onload = function() {connectionChecked = established = true; clearTimeout(checkConn);}
		}

		checkAjax = setInterval(function() {
			if(self.connection.check && !connectionChecked) {
				return false;
			}

			if(!connection) {
				if(null != checkAjax) {
					clearInterval(checkAjax);
				}			
				var temp = nested;
				for(var i=processed; i<ajaxQueue.length; i++) {
					if(typeof ajaxQueue[i].error === 'function') {
						ajaxQueue[i].error(i+1, window.location.href, '', 'connection', 'Error Establishing Connection', ajaxQueue.length, temp);
					}
						
					temp = false;
				}
				
				for(var i=processed; i<ajaxQueue.length; i++) {
					if(typeof ajaxQueue[i].always === 'function') {
						ajaxQueue[i].always(i+1, ajaxQueue.length, false, nested);
					}
						
					nested = false;
				}
				trigger('complete');
			}
			else {
				if(processed < ajaxQueue.length) {
					if(!loading) {
						if(cancelNum === processed) {
							loading = false;
							processed += 1;
							if(processed > ajaxQueue.length) {processed = ajaxQueue.length;}						
							var url = ajaxQueue[processed-1].url;							
							if(typeof ajaxQueue[processed].error === 'function') {
								ajaxQueue[processed].error(processed, getURL(url), getQueryData(url), 'abort', 'Request Skipped', ajaxQueue.length, nested);
							}							
							if(typeof ajaxQueue[processed].always === 'function') {
								ajaxQueue[processed].always(processed, ajaxQueue.length, false, nested);
							}							
							nested = false;
						}
						if(processed < ajaxQueue.length) {
							self.request(ajaxQueue[processed]);
						}
					}
				}
				else if(processed === ajaxQueue.length) {
					if(null != checkAjax) {
						clearInterval(checkAjax);
					}
					trigger('complete');
				}
			}
		}, 100);
		
		return this;
	}
	this.prop = function(reqNum, property, value) {
		if(null != value) {
			ajaxQueue[reqNum-1][property] = value;
			
			return this;
		}
		else {
			return (ajaxQueue[reqNum-1][property] || self[property]);
		}
	}
	this.isDone = function(reqNum) {
		return (processed >= reqNum);
	}
	this.isWorking = function() {
		return (processed >= 0 && processed < ajaxQueue.length);
	}
};