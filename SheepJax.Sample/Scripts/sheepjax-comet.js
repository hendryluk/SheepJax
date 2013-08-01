(function ($) {
    $.sheepJax.addDefaultCommands({
        CometConnect: function(clientId, batchInterval) {
            var opt = this;
            var completed = false;
            opt.commands._$CometDisconnect = function(success) {
                completed = true;
                if (!success)
                    opt.cometError();
            };

            var longPoll = function() {
                if (!completed) {
                    $.ajax({
                        dataType: "json",
                        url: "/SheepJaxLongPoll.axd",
                        data: { clientId: clientId },
                        type: "POST",
                        success: function(data) {
                            handleCallback(opt, data);
                        },
                        complete: function() {
                            setTimeout(longPoll, batchInterval);
                        }
                    });
                }
            };

            setTimeout(longPoll, batchInterval);
        }
    });
})(jQuery);