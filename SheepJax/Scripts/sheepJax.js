(function ($) {
    var me = function (options) {
        var opt = getOptions(options);

        opt.before();
        $.ajax({
            dataType: opt.dataType,
            url: opt.url,
            data: opt.data,
            type: opt.type,
            error: opt.error,
            complete: function () { opt.complete(); },
            success: function (data) { handleCallback(opt, data); }
        });
    };

    function getOptions(options) {
        var opt = $.extend({}, me.defaultOptions, options);
        opt.commands = $.extend({}, me.defaultCommands, opt.commands);
        return opt;
    }

    function handleCallback(opt, data) {
        for (var i in data) {
            var func = opt.commands[data[i].FunctionName];
            if (func) {
                func.apply(opt, data[i].Args);
            } else {
                opt.commands.FunctionUndefined(data, data[i].FunctionName);
                break;
            }
        }
    }

    // DEFAULTS
    $.extend(me, {
        defaultOptions: {
            url: null,
            type: 'POST',
            data: {},
            dataType: 'json',
            async: true,
            commands: {},
            target: undefined,
            error: undefined,
            before: function () { },
            complete: function () { },
            cometError: function () {
                alert("An error occurred attempting to process your request. This error has been logged.");
            }
        },
        defaultCommands: {
            RedirectPage: function (url) {
                window.location = url;
            },
            ReloadPage: function () {
                window.location.reload(true);
            },
            Append: function (selector, content) {
                $(selector, this.target).append(content);
            },
            Replace: function (selector, content) {
                $(selector, this.target).replaceWith(content);
            },
            SetHtml: function (selector, content) {
                $(selector, this.target).html(content);
            },
            Remove: function (selector) {
                $(selector, this.target).remove();
            },
            Hide: function (selector) {
                $(selector, this.target).hide();
            },
            Show: function (selector) {
                $(selector, this.target).show();
            },
            WritePage: function (content) {
                document.open();
                document.write(content);
                document.close();
            },
            FunctionUndefined: function (data, functionName) {
                $.error('FunctionName ' + functionName + ' does not exist on the commands');
            },
            CometConnect: function (clientId, batchInterval) {
                var opt = this;
                var completed = false;
                opt.commands._$CometDisconnect = function (success) {
                    completed = true;
                    if (!success)
                        opt.cometError();
                };

                var longPoll = function () {
                    if (!completed) {
                        $.ajax({
                            dataType: "json",
                            url: "/SheepJax/LongPoll",
                            data: { clientId: clientId },
                            type: "POST",
                            success: function (data) {
                                handleCallback(opt, data);
                            },
                            complete: function () {
                                setTimeout(longPoll, batchInterval);
                            }
                        });
                    }
                };

                setTimeout(longPoll, batchInterval);
            }
        },
        addDefaultCommands: function (commands) {
            $.extend(me.defaultCommands, commands);
        },
        handleCallback: function (opt, data) {
            handleCallback(getOptions(opt), data);
        }
    });

    $.sheepJax = me;

})(jQuery);

(function ($) {
    function hijaxForm(event, options) {
        if (event.isPropagationStopped())
            return;

        var $form = $(event.target);
        if (!$form.is("form"))
            return;

        event.preventDefault();
        $.sheepJax($.extend({
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize(),
            event: event
        },
            $form.data("sheepHijaxOptions"),
            options));
    }

    function hijaxLink(event, options) {
        if (event.isPropagationStopped())
            return;

        var $link = $(event.target);
        if (!$link.is("a"))
            return;

        event.preventDefault();
        if ($form.valid && !$form.valid())
            return false;

        $.sheepJax($.extend({
            url: $link.attr("href"),
            event: event
        },
            $link.data("sheepHijaxOptions"),
            options));
    }

    $.fn.sheepHijax = function (options) {
        this.filter("form").submit(function (e) { hijaxForm(e, options); });
        this.filter("a").click(function (e) { return hijaxLink(e, options); });
        return this;
    };

    $.fn.sheepHijaxLive = function (options) {
        this.live("submit", function (e) { hijaxForm(e, options); });
        this.live("click", function (e) { return hijaxLink(e, options); });
        return this;
    };

    $(document).ready(function () {
        $(".sheepHijax").sheepHijaxLive();
    });
})(jQuery);