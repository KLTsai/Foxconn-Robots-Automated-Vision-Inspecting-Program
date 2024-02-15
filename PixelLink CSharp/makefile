!include $(BUILD_TOOLS)\makefile.vs08

#//
#// Build everything
#//
build:
	@set DEMO_NAME=AutoWhiteBalance
	@$(MAKE) build_demo
	@set DEMO_NAME=Callback
	@$(MAKE) build_demo
	@set DEMO_NAME=Callback2
	@$(MAKE) build_demo
	@set DEMO_NAME=Ffc
	@$(MAKE) build_demo
	@set DEMO_NAME=GetCameraFeature
	@$(MAKE) build_demo
	@set DEMO_NAME=GetCameraInfo
	@$(MAKE) build_demo
	@set DEMO_NAME=GetSnapshot
	@$(MAKE) build_demo
	@set DEMO_NAME=Initialize
	@$(MAKE) build_demo
	@set DEMO_NAME=PreviewInWindow
	@$(MAKE) build_demo
	@set DEMO_NAME=Triggering
	@$(MAKE) build_demo


#//
#// Set the environment var DEMO_NAME to the name of the demo to build
#//
build_demo:
	@set SOLUTION_DIR="%%DEMO_NAME%%\"
	@set SOLUTION=%DEMO_NAME%\%%DEMO_NAME%%
	@$(MAKE) clean_build_tidyup
